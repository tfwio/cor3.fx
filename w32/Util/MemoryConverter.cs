using System;
using System.Runtime.InteropServices;
using w32.kernel;

namespace Cor3
{


	unsafe public class MemoryConverter : Kernel32, IDisposable
	{
		public GCHandle GCMem;
		public IntPtr MemAddress = IntPtr.Zero;
		public byte[] MemBytes;
		/// <summary>
		/// simple automation of MemBytes
		/// </summary>
		byte[] this[int size] { get { return MemBytes = new byte[size]; } }

		public string GetStringAnsi(IntPtr str_mem) { return Marshal.PtrToStringAnsi(str_mem); }
		public string GetStringAuto(IntPtr str_mem) { return Marshal.PtrToStringAuto(str_mem); }
		public int GetInt() { return Marshal.ReadInt32(this); }

		/// <param name="size">the size of the memory block</param>
		/// <param name="type">
		/// One of the GCHandleType values indicating the type of GCHandle to create.
		/// </param>
		/// <returns>
		/// GCHandle structure which needs to be freed using the *.Free() method
		/// unless *.Dispose() is called which frees memory.
		/// </returns>
		public GCHandle GCAlloc(int size, GCHandleType gch_type)
		{
			GCHandle GCMem = GCHandle.Alloc(this[size],gch_type);
			MemAddress = Marshal.UnsafeAddrOfPinnedArrayElement(MemBytes,0);
			return GCMem;
		}
		public GCHandle GCAllocPinned(int size)
		{
			return GCAlloc(size, GCHandleType.Pinned);
		}

		public void CopyPinned(int mem_size, IntPtr src)
		{
			GCHandle gch = GCAlloc(mem_size, GCHandleType.Pinned);
			CopyMemory(MemAddress,src,mem_size);
			gch.Free();
		}
		
		/// <summary>
		/// Initializes a GCHandle structure (which needs to be freed,
		/// automating preparation for w32.kernel 'CopyMemory' API.
		/// </summary>
		/// <param name="size">the size of the memory block</param>
		/// <param name="type">
		/// One of the GCHandleType values indicating the type of GCHandle to create.
		/// </param>
		/// <remarks>
		/// You can 'Dispose' this object to call *.GCMem.Free()
		/// </remarks>
		public MemoryConverter(int size, GCHandleType type) { GCMem = GCAlloc(size,type); }
		/// <summary>
		/// Initializes a GCHandle structure (which needs to be freed,
		/// automating preparation for w32.kernel 'CopyMemory' API.
		/// </summary>
		/// <param name="size">the size of the memory block</param>
		/// <remarks>
		/// equivelant to calling the overload with GCHandleType.Fixed as the 
		/// second parameter.<br/>
		/// You can 'Dispose' this object to call *.GCMem.Free()
		/// </remarks>
		public MemoryConverter(int size) : this(size,GCHandleType.Pinned) { }

		~MemoryConverter() { Dispose(); }

		static public implicit operator byte[] (MemoryConverter mem){ return mem.MemBytes; }
		static public implicit operator string (MemoryConverter mem){ return mem.GetStringAuto(mem.MemAddress); }
		static public implicit operator IntPtr (MemoryConverter mem){ return mem.MemAddress; }
		static public implicit operator GCHandle (MemoryConverter mem){ return mem.GCMem; }
		static public implicit operator int (MemoryConverter mem){ return mem.GetInt(); }
		
		public void Dispose()
		{
			Array.Clear(MemBytes,0,MemBytes.Length); // this is to be tested
			GCMem.Free();							 // as it maybe of concern.
		}
	}
}
