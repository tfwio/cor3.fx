#if msb_35
/* oOo * 12/29/2007 : 9:42 AM */
using System;
using System.IO;
using System.Security;
using System.Collections;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace _X.MSBuild
{
	/*
	 * Class: MakeDir
	 *
	 * An MSBuild task that creates one or more directories.
	 *
	 */
	public class MakeDir : Task
	{
		[Required]
		public ITaskItem[] Directories { get { return directories; } set { directories = value; } }

		[Output]
		public ITaskItem[] DirectoriesCreated { get { return directoriesCreated; } }

		private ITaskItem[] directories;
		private ITaskItem[] directoriesCreated;

		public override bool Execute()
		{
			ArrayList items = new ArrayList();
			foreach (ITaskItem directory in Directories)
			{
				if (directory.ItemSpec.Length > 0)
				{
					try
					{
						if (!Directory.Exists(directory.ItemSpec))
						{
							Log.LogMessage(MessageImportance.Normal, "Creating directory " + directory.ItemSpec);
							Directory.CreateDirectory(directory.ItemSpec);
						}
						items.Add(directory);
					}
					catch (Exception ex)
					{
						if (ex is IOException
							|| ex is UnauthorizedAccessException
							|| ex is PathTooLongException
							|| ex is DirectoryNotFoundException
							|| ex is SecurityException)
						{
							Log.LogError("Error trying to create directory " + directory.ItemSpec + ". " + ex.Message);
						}
						else
						{
							throw;
						}
					}
				}
			}

			directoriesCreated = (ITaskItem[])items.ToArray(typeof(ITaskItem));
			return !Log.HasLoggedErrors;
		}
	}
}

#endif