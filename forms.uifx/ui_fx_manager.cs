/**
 * tfw * 2/25/2009 * 2:08 PM
**/
using System;
using System.Cor3;
using System.Cor3.Forms;
using System.Cor3.man;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using fam3;

using w32.gdi;
using w32.kernel;

namespace Cor3.forms
{
    public class ui_fx_manager : object_manager<ui_fx_frm>
    {
        const string filter = "UI:Theme Resource (*.msstyles)|*.msstyles|Shell-DLL|*.dll|All Resources (*.msstyles;*.dll)|*.msstyles;*.dll|All Files|*";
        const string filter_expo = "UI:Theme Resource Xml (*.xml)|*.xml|All Files|*";
        const string cap_loadexpo = "Load Xml Export File...";
        const string err_caption = "no worry!";
        const string err_stat = "min: {0}, max: {1}";
        const string err_file_loaded = "File is allready loaded!";
        const string ask_b4cls = "you sure?";
        const string default_key_root = "brick";
        const string default_item_key = "tag";
        const string def_caption0 = "ResUtil {0} ";
        const string def_caption1 = "ResUtil {0} : {1}";
        ToolStripItem sepr8 = new ToolStripSeparator();

        bool DoWait
        {
            get {
                return Client.UseWaitCursor;
            } set {
                /*Client.stat.Visible =*/
                Client.splitter3.Panel2Collapsed = ! (
                                                       Client.UseWaitCursor =
                                                               /*!(Client.toolstrip.Visible = !*/
                                                               value
                                                               /*)*/
                                                   );
            }
        }

        treeview_node_mover treeman;
        MOD_DICT Resources = new MOD_DICT();
        img_dict _res;
        img_res _i;

        void UpdateTree()
        {
            Client.tvRes.Nodes.Clear();
            foreach (string val in Resources.ToKeyArray())
                Client.tvRes.Nodes.Add(_tn(Resources[val]));
        }

        /// could be a key, could be a node...
        TreeNode _tn(TreeNode tn, object type, object name, LibLoader2 ld)
        {
            ContextMenuStrip cms = _tns(tn,type,name,ld);
            if (cms!=null) tn.ContextMenuStrip = cms;
            else Global.cstat(ConsoleColor.Yellow,cms);
//			res_table rt = find(type,name,ld);
//			if (rt!=null) tn.Tag = rt;
//			Global.stat(rt);
            return _tn(tn);
        }
        TreeNode _tn(TreeNode tn)
        {
            if (tn.Level>=2) {
                tn.ImageKey = tn.SelectedImageKey = _i["table"];
            } else {
                if (_i.ContainsKey(tn.Text)) tn.ImageKey = tn.SelectedImageKey = _i[tn.Text];
                else tn.ImageKey = tn.SelectedImageKey = default_item_key;
            }
            return tn;
        }
        TreeNode _tn(LibLoader2 loader)
        {
            TreeNode tn = new TreeNode(Path.GetFileName(loader.LibraryPath));
            tn.ImageKey = tn.SelectedImageKey = default_key_root;
            tn.Tag = loader;
            tn.ContextMenuStrip = _tns(loader);
            return DoEnum(tn);
        }

        res_table find(object type, object name,LibLoader2 ld)
        {
            foreach (res_table rt in ld.table_data) if (rt.Compare(type,name)) {
                    return rt;
                }
            Global.cstat(ConsoleColor.Red,"error: {0}", ld.table_data.Count);
            return null;
        }
        res_table _r(TreeNode o)
        {
            if (o.Tag is res_table) return (res_table)o.Tag;
            return null;
        }
        res_table _r(object o)
        {
            if (o is TreeNode) return _r(o as TreeNode);
            return null;
        }

        thought? _rt(ToolStripItem obj)
        {
            if (obj.Tag is thought) return (thought)obj.Tag;
            return null;
        }
        thought? _rt(TreeNode obj)
        {
            if (obj.Tag is thought) return (thought)obj.Tag;
            return null;
        }
        thought? _rt(object obj)
        {
            if (obj is ToolStripItem) return _rt(obj as ToolStripItem);
            if (obj is TreeNode) return _rt(obj as ToolStripItem);
            return null;
        }

        bool _msg(string str)
        {
            return _msg (str,err_caption,false);
        }
        bool _msg(string str, string caption, bool console)
        {
            if (!console) MessageBox.Show (str,caption);
            else Global.cstat ( ConsoleColor.Red,str );
            return false;
        }

        bool checkTag(object sender)
        {
            thought? rt = _rt(sender);
            if (rt==null) return _msg("unexpected tag");
            return true;
        }

        void eSavIco(object sender, EventArgs e)
        {
            thought? rt = _rt(sender);
            if (rt==null) {
                _msg("unexpected tag");
                return;
            }
            Icon ico = LoadIcon(rt);
            SaveImage(ico);
        }

        void TrySaveImage(string filename, Bitmap image, BITMAPINFOHEADER info)
        {
            PixelFormat pf = GetFmt(info);
//			if (info.biBitCount==32)
        }
        void eSavBmp(object sender, EventArgs e)
        {
            thought? rt = _rt(sender);
            if (rt==null) {
                _msg("unexpected tag");
                return;
            }
            Bitmap bmp = LoadBitmap(rt);
            SaveImage(bmp, ExportType.bitmap);
        }
        void eSavPng(object sender, EventArgs e)
        {
            thought? rt = _rt(sender);
            if (rt==null) {
                _msg("unexpected tag");
                return;
            }
            Bitmap bmp = LoadPng(rt);
            SaveImage(bmp, ExportType.png);
        }
        void eSavRaw(object sender, EventArgs e)
        {
            thought? rt = _rt(sender);
            if (rt==null) {
                _msg("unexpected tag");
                return;
            }
            byte[] bits = LoadBinary(rt);
            SaveImage(bits);
        }

        string get_filter(ExportType typ)
        {
            return get_filter(typ,false);
        }
        string get_filter(ExportType typ, bool savemode)
        {
            if (savemode) switch (typ) {
                case ExportType.any:
                    return ("All files (*)|*.*");
                case ExportType.binary:
                    return ("Binary (*.*)|*.*");
                case ExportType.png:
                    return ("PNG Image (*.png)|*.png");
                case ExportType.bitmap:
                    return ("Microsoft Bitmap Image (*.bmp)|*.bmp");
                case ExportType.icon:
                    return ("Microsoft Icon Image (*.ico)|*.ico");
                }
            else switch (typ) {
                case ExportType.any:
                    return ("All files (*)|*.*");
                case ExportType.binary:
                    return ("Binary (*.bin)|*.*");
                case ExportType.png:
                    return ("PNG Image (*.png)|*.png");
                case ExportType.bitmap:
                    return ("Microsoft Bitmap Image (*.bmp)|*.bmp");
                case ExportType.icon:
                    return "Microsoft Icon Image (*.ico)|*.ico";
                }
            return "All Files (*)|*.*";
        }

        void AutoSaveImage(thought? tho, BITMAPINFOHEADER bih, byte[] img)
        {
            if (bih.biBitCount==32) {
                // save a png
                Bitmap bmp = LoadPng(tho);
            } else {
                // save a bmp
                Bitmap bmp = LoadBitmap(tho);
            }
        }
        /// save and destroy data
        void SaveImage(byte[] img)
        {
            string fn = ControlUtil.FSave(get_filter(ExportType.binary,true));
            if (fn!=string.Empty) SaveImage(fn,img);
        }
        void SaveImage(string path,byte[] img)
        {
            if (path!=string.Empty) {
                File.WriteAllBytes(path,img);
                Array.Clear(img,0,img.Length);
            }
        }
        /// save and destroy data
        void SaveImage(Bitmap img, ExportType typ)
        {
            string fn = ControlUtil.FSave(get_filter(typ,true));
            if (fn!=string.Empty) {
                SaveImage(fn,img,typ);
            }
        }

//		Bitmap PostFormatImage(BITMAPINFOHEADER info, Bitmap img)
//		{
//			Bitmap bmpOut;
//			switch (info.biBitCount)
//			{
//				case 1: return new Bitmap(img,PixelFormat.Format1bppIndexed);
//				case 4: return new Bitmap(img,PixelFormat.Format4bppIndexed);
//				case 8: return new Bitmap(img,PixelFormat.Format8bppIndexed);
//				case 16: return new Bitmap(img,PixelFormat.Format16bppRgb565);
//				case 24: return new Bitmap(img,PixelFormat.Format24bppRgb);
//				case 32: return new Bitmap(img,PixelFormat.Format32bppArgb);
//			}
//		}
        PixelFormat GetFmt(BITMAPINFOHEADER info)
        {
            switch (info.biBitCount) {
            case 1:
                return PixelFormat.Format1bppIndexed;
            case 4:
                return PixelFormat.Format4bppIndexed;
            case 8:
                return PixelFormat.Format8bppIndexed;
            case 16:
                return PixelFormat.Format16bppRgb565;
            case 24:
                return PixelFormat.Format24bppRgb;
            case 32:
                return PixelFormat.Format32bppArgb;
            default:
                return PixelFormat.Format24bppRgb;
            }
        }
        Rectangle srcRect(Bitmap img)
        {
            return new Rectangle(0,0,img.Size.Width,img.Size.Height);
        }
        // Only Images (auto:PNG|BMP)
        void SaveImage(string fn, thought? thinker, BITMAPINFOHEADER info)
        {
            PixelFormat pf = GetFmt(info);
            if (File.Exists(fn)) File.Delete(fn);
            using (Bitmap bmpReturn = (info.biBitCount==32)?
                                      LoadPng(thinker) : LoadBitmap(thinker,info)) {
                Rectangle r = new Rectangle(0,0,info.biWidth-1,info.biHeight-1);
                using (Bitmap newReturn = bmpReturn.Clone(r,bmpReturn.PixelFormat)) {
                    if (info.biBitCount==32) newReturn.Save(fn,ImageFormat.Png);
                    else {
                        try {
                            newReturn.Save(fn,ImageFormat.Bmp);
                        } catch {
                            MessageBox.Show(newReturn.ToString());
                        }
                    }
                }
            }
        }
        void SaveImage(string fn, Bitmap img, ExportType typ)
        {
            if (fn!=string.Empty) {
                switch (typ) {
                case ExportType.bitmap:
                    img.Save(fn,ImageFormat.Bmp);
                    break;
                case ExportType.png:
                    img.Save(fn,ImageFormat.Png);
                    break;
                case ExportType.icon:
                    img.Save(fn,ImageFormat.Icon);
                    break;
                }
                img.Dispose();
            }
        }
        /// save and destroy data
        void SaveImage(Icon img)
        {
            string file = ControlUtil.FSave(get_filter(ExportType.icon,true));
            using (FileStream fs = new FileStream(file,FileMode.Create)) {
                img.Save(fs);
                img.Dispose();
            }
        }

        byte[] LoadBinary(thought? rt)
        {
            IntPtr res = ResLoader.FindData(rt.GetValueOrDefault());
            byte[] filedata = null;
            if (res != IntPtr.Zero) filedata = ResLoader.FindData(rt.Value.loader,rt.Value.table,true);
            res = IntPtr.Zero;
            return filedata;
        }
        Icon LoadIcon(thought? rt)
        {
            IntPtr res = ResLoader.FindData(rt.GetValueOrDefault().loader,rt.GetValueOrDefault().table,ImageType.icon);
            if (res != IntPtr.Zero) {
                Icon ico = Icon.FromHandle(res);
                return ico;
            } else Global.cstat(ConsoleColor.Red,"unexpected IntPtr");
            return null;
        }

        Bitmap LoadHImage(thought? obj, BITMAPINFOHEADER info)
        {
            Bitmap ico = null;
            IntPtr res = ResLoader.FindData(info.biWidth,info.biHeight, obj.GetValueOrDefault().loader,obj.GetValueOrDefault().table,ImageType.srcbitmap);
            return Bitmap.FromHbitmap(res);
        }
        Bitmap LoadBitmap(thought? obj)
        {
            Bitmap ico = null;
            IntPtr res = ResLoader.FindData(obj.GetValueOrDefault().loader,obj.GetValueOrDefault().table,ImageType.bitmap);
            if (res != IntPtr.Zero) ico = Bitmap.FromHbitmap(res);
            else Global.cstat(ConsoleColor.Red,"unexpected IntPtr");
            res = IntPtr.Zero;
            return ico;
        }
        Bitmap LoadBitmap(thought? obj, BITMAPINFOHEADER info)
        {
            PixelFormat pf = GetFmt(info);
            Bitmap ico,png = null;
            IntPtr res = ResLoader.FindData(obj.GetValueOrDefault().loader,obj.GetValueOrDefault().table,ImageType.bitmap);
            if (res != IntPtr.Zero) {
                using (ico = Bitmap.FromHbitmap(res)) {
                    Rectangle rect = new Rectangle(0,0,ico.Size.Width,ico.Size.Height);
//					MessageBox.Show(ico.PixelFormat.ToString(),ico.Size.ToString());
                    png = ico.Clone(rect,ico.PixelFormat);
                }
            } else Global.cstat(ConsoleColor.Red,"unexpected IntPtr");
            return png;
        }
        Bitmap LoadPng(thought? obj)
        {
            Bitmap ico,png = null;
            IntPtr res = ResLoader.FindData(obj.GetValueOrDefault().loader,obj.GetValueOrDefault().table,ImageType.bitmap);
            if (res != IntPtr.Zero) {
                ico = Bitmap.FromHbitmap(res);
                png = new Bitmap(ico.Width,ico.Height,PixelFormat.Format32bppPArgb);
                Rectangle copyArea = new Rectangle(0, 0, ico.Width, ico.Height);
                byte[] bits = ResLoader.FindData(obj.GetValueOrDefault().loader,obj.GetValueOrDefault().table,true);
                BitmapData alphaBits = png.LockBits(copyArea,ImageLockMode.WriteOnly,PixelFormat.Format32bppArgb);
                IntPtr firstCopyElement = Marshal.UnsafeAddrOfPinnedArrayElement(bits,40);
                Kernel32.CopyMemory (alphaBits.Scan0,firstCopyElement,bits.Length - 40);
                png.UnlockBits (alphaBits);
                png.RotateFlip (RotateFlipType.RotateNoneFlipY);
                ico.Dispose();
//				}
            } else Global.cstat(ConsoleColor.Red,"unexpected IntPtr");
            return png;
        }

        ContextMenuStrip _tns(TreeNode tn,object type, object name,LibLoader2 ld)
        {
            ContextMenuStrip cms = new ContextMenuStrip();
            string typ = type.ToString();
            if (RT_STR.has_value(typ)) typ = ((RC_ENUM)RT_STR.get_int(typ)).ToString();
//			else Global.cstat(ConsoleColor.Red,"hasn't the value {0}",typ);
            ToolStripMenuItem tsi = new ToolStripMenuItem(string.Format("type: {0}, name: {1}",typ,name));
            res_table rt = find(type,name,ld);
            if (rt!=null) tsi.Tag = tn.Tag = new thought(ld,rt);
            else Global.cstat(ConsoleColor.Yellow,name);
            tsi.Click += eSavRaw;

            ToolStripItem tsi2 = new ToolStripMenuItem("save bmp",null,eSavBmp);
            ToolStripItem tsi3 = new ToolStripMenuItem("save ico",null,eSavIco);
            ToolStripItem tsi4 = new ToolStripMenuItem("save png",null,eSavPng);
//			ToolStripItem tsi5 = new ToolStripMenuItem("show UNICODE",null,eUni);
//			ToolStripItem tsi5 = new ToolStripMenuItem("show Ansi",null,eAnsi);
//			ToolStripItem tsi5 = new ToolStripMenuItem("show Binary",null,eBin);
            tsi2.Tag = tsi3.Tag = tsi4.Tag = tsi.Tag;
            cms.Items.Add(tsi);
            cms.Items.Add(tsi2);
            cms.Items.Add(tsi4);
            cms.Items.Add(tsi3);
            cms.Items.Add(sepr8);
//			cms.Items.Add(tsi5);

            return cms;
        }
        ContextMenuStrip _tns(LibLoader2 loader)
        {
            ContextMenuStrip cms = new ContextMenuStrip();
//			cms.Renderer = new ts_renderer();
            ToolStripItem tsi = new ToolStripMenuItem("Save Resource-Info (*.res.xml)",famfam_silky.disk,eSaveInfo);
            tsi.Tag = loader.LibraryPath;
            cms.Items.Add(tsi);
            return cms;
        }

        LibLoader2 _loader(TreeNode tn)
        {
            return IsLoader(tn)?tn.Tag as LibLoader2:null;
        }
        /// for TreeNode EventHandlers' 'sender' object
        LibLoader2 _loader(object tn)
        {
            return IsLoader(tn)?(tn as TreeNode).Tag as LibLoader2:null;
        }

        /// for TreeNode EventHandlers' 'sender' object
        bool IsLoader(object tn)
        {
            return (tn is TreeNode) ? (tn as TreeNode).Tag is LibLoader2 : false;
        }
        bool IsLoader(TreeNode tn)
        {
            return tn.Tag is LibLoader2;
        }
        bool IsLoaded(LibLoader2 ld)
        {
            return (ld==null)?false:ld.IsLoaded;
        }
        bool IsLoaded(TreeNode tn)
        {
            return IsLoader(tn)?_loader(tn).IsLoaded:false;
        }

        int CountTypes(LibLoader2 libthing)
        {
            int Counter = 0;
            foreach (object key in libthing.ResourceItems.ToKeyArray()) {
                foreach (object key2 in libthing.ResourceItems[key]) Counter++;
            }
            return Counter;

        }
        void DoEnum()
        {
            DoEnum (Client.tvRes.SelectedNode);
        }
        TreeNode DoEnum(TreeNode tn)
        {
            LibLoader2 node;
            if ((node = _loader(tn))!=null) {
                tn.Nodes.Clear();
                bool bob = node.EnumTypes();
                DoWait = true;
                int CountMax = CountTypes(node),CurrentCount = 0;
                Client.stat.Maximum = CountMax;
                foreach (object key in node.ResourceItems.ToKeyArray()) {
                    Application.DoEvents();
                    TreeNode node_type = new TreeNode(tutil._s(key));
                    foreach (object key2 in node.ResourceItems[key]) {
                        Application.DoEvents();
                        _tn(node_type.Nodes.Add(tutil._s(key2)),key,key2,node);
                        try {
                            Client.stat.Value = CurrentCount;
                        } catch {
                            MessageBox.Show(string.Format(err_stat,Client.stat.Minimum,Client.stat.Maximum),err_caption);
                        }
                        CurrentCount++;
                    }
                    tn.Nodes.Add(_tn(node_type));
                }
            }
            DoWait = false;
            return tn;
        }

        res_info LoadExpo()
        {
            string file = ControlUtil.FGet(filter_expo,cap_loadexpo);
            if (file==string.Empty) return null;
            return LoadExpo(file);
        }
        res_info LoadExpo(string file)
        {
            res_info ri = res_info.Load(file);
            return ri;
        }

        void LoadPE()
        {
            string fname = ControlUtil.FGet(filter,"Load msstyle file or dll");
            if (fname==string.Empty) return;
            LoadPE(fname);
        }
        void LoadPE(string fname)
        {
            Resources.AddModule ( /*Path.GetFileName*/ (fname) );
            UpdateTree ();
        }

        void eSaveInfo(object sender, EventArgs args)
        {
            string name = (sender as ToolStripItem).Tag as string;
            if (name==null) throw new ArgumentException("argument didn't exist?..");
            if (Resources.ContainsKey(name)) Resources[name].SaveXml();
        }
        void eExportInfo(object sender, EventArgs args)
        {
            string name = (sender as ToolStripItem).Tag as string;
            if (name==null) throw new ArgumentException("argument didn't exist?..");
            if (Resources.ContainsKey(name)) Resources[name].SaveXml();
        }
        const string bp = "Select a Directory To DUMP Resource Data\nnote: a directory named {0} will be created for you";
        string ckname(thought? th, BITMAPINFOHEADER nfo)
        {
            string ext = (nfo.biBitCount==32) ? ".png" : ".bmp";
            return th.Value.table.name.Replace("_BMP",ext).Replace('_','\\');
        }
        string ckpath(string p0,string p1)
        {
            string xpath = Path.Combine(p0,p1);
            FileInfo fi = new FileInfo(xpath);
            if (!fi.Directory.Exists) Directory.CreateDirectory(fi.Directory.FullName);
            return xpath;
        }
        void eExportInfoDump(object sender, EventArgs args)
        {
            if (Client.tvRes.SelectedNode.Index!=0) {
                MessageBox.Show(res.err_pe_load,"first");
                return;
            }
            string name = ((Client.tvRes.SelectedNode).Tag as LibLoader2).LibraryPath;
            if (name==null) {
                throw new ArgumentException(string.Format(res.err_arg_filter,(Client.tvRes.SelectedNode).Tag));
            }
            MessageBox.Show(name);
            string pathname = Path.GetFileNameWithoutExtension(name);
            string basepath = Cor3.FileUtil.GetDir(string.Format(bp,pathname));
            if (basepath == string.Empty) return;
            string newdir = DirUtil.CreateIfNoExist(Path.Combine(basepath,pathname));
            string stroutput = string.Empty;
            res_info wry = Resources[name].ToResInfo();
            foreach (res_category ri in wry.table_data) {
                string tpath = DirUtil.CreateIfNoExist(Path.Combine(newdir,string.Format("{0}",ri.table_id)));
                foreach (res_table rt in ri.table_data) {
                    thought? t = new thought(Resources[name],ri.table_id,rt._n,rt.Lang);
                    Application.DoEvents();
                    byte[] bits = LoadBinary(t);
                    if (t.GetValueOrDefault().table.type=="BITMAP") {
                        BITMAPINFOHEADER bih = BITMAPINFOHEADER.CreateMemory(bits);
                        string imagename = ckpath(tpath,ckname(t,bih)); // convert the dir/name
                        SaveImage(imagename,t,bih);
                        rt.ext_info = imagename;
                    } else {
                        SaveImage(Path.Combine(tpath,rt.name),bits);
                    }
                    t = null;
                    stroutput += string.Format("{0}:{1}\n",rt._n,rt._t);
                }
            }
            if (Resources.ContainsKey(name)) Resources[name].SaveXml(wry,newdir,pathname);
            Client.richTextBox1.Text = stroutput;
        }
        void eLoadExpo(object s, EventArgs e)
        {
            res_info ri = LoadExpo();
            if (File.Exists(ri.lib.pe_path)) LoadPE(ri.lib.pe_path);
            if (ri.table_data!=null) {
                string tstr = string.Format("{0}\n",ri.table_data.Length);
                foreach (res_category rc in ri.table_data) {
                    tstr += string.Format("type:{0}\n",rc.table_id);
                    foreach (res_table rt in rc.table_data)
                        tstr += string.Format("\t{1}:{0}\n",rt._n,rt._t);
                }
                Client.richTextBox1.Text = tstr;
            } else Client.richTextBox1.Text = "TABLE DATA EMPTY";
            MessageBox.Show("shit!!");
        }
        void eAddDLLFile(object sender, EventArgs args)
        {
            LoadPE();
        }
        void eRemDLLFile(object sender, EventArgs args)
        {
            Resources.Remove (Client.tvRes.SelectedNode.Text);
            Client.tvRes.Nodes.Remove (Client.tvRes.SelectedNode);
        }
        void eTvSelChanged(object sender, TreeViewEventArgs args)
        {
            Client.tsRemDLL.Enabled =
                Client.lbl_good.Enabled =
                    Client.btn_types.Enabled = IsLoaded (args.Node);
            thought? rv = _rt(args.Node);
            if (rv.HasValue) {
                Client.lbtv.Text = string.Format(
                                       def_caption1,
                                       rv.GetValueOrDefault().table.type,
                                       rv.GetValueOrDefault().table.name
                                   );
//			else
//				Client.lbtv.Text = string.Format(def_caption1,rv.name,rv.type);
                if (Client.btn_preview.Checked) {
                    byte[] bits;
                    switch(rv.GetValueOrDefault().table.type) {
                    case "BITMAP":
                        break;
                    case "COLORNAMES":
                    case "COMBODATA":
                    case "FILERESNAMES":
                    case "ORIGFILENAMES":
                    case "PACKTHEM_VERSION":
                    case "SIZENAMES":
                    case "TEXTFILE":
                        bits = LoadBinary(rv);
                        Client.richTextBox1.Text = System.Text.Encoding.Unicode.GetString(bits);
                        Array.Clear(bits, 0, bits.Length);
                        break;
                    case "UIFILE":
                    case "HTML":
                        bits = LoadBinary(rv);
                        Client.richTextBox1.Text = System.Text.Encoding.Default.GetString(bits);
                        Array.Clear(bits, 0, bits.Length);
                        break;
                    }
                }
            }

        }
        void eEnumTypes(object s, EventArgs args)
        {
            DoEnum ();
        }
        void eRtfFon(object sender, EventArgs e)
        {
            Client.richTextBox1.Font = Client.rtfFont.SelectedFont;
        }

        public override void AddEvents()
        {
            Client.rtfFont.SelectedIndexChanged += eRtfFon;
            Client.tsRemDLL.Click += eRemDLLFile;
            Client.tsAddDLL.ButtonClick += eAddDLLFile;
            Client.tvRes.AfterSelect += eTvSelChanged;
            Client.btn_types.Click += eEnumTypes;
            Client.btn_loadExpo.Click += eLoadExpo;
            Client.btn_exportXmlToolStripMenuItem.Click += eExportInfo;
            Client.btn_exportXmlandDumpToolStripMenuItem.Click += eExportInfoDump;
        }

        void InitializeDictionaries()
        {
//		string[] res_ids = {
//			"Cursor","Bitmap","Icon","Menu","Dialog",
//			"String","Font-Dir","Font","Accelerator","Message Table",
//			"Cursor Group","Icon Group","Version","DialogInclude","PlugPlay",
//			"VXD","Animated-Cursor","Animated-Icon","HTML","Manifest",
//			"(Custom)"
//		};
            _i = new img_res();
            _i.AddRange(
                new img_res.DictNode("COLORNAMES","color"),
                new img_res.DictNode("COMBODATA","cbodata"),
                new img_res.DictNode("FILERESNAMES","tdb"),
                new img_res.DictNode("MINDEPTH","tdb"),
                new img_res.DictNode("ORIGFILENAMES","tdb"),
                new img_res.DictNode("PACKTHEM_VERSION","tdb"),
                new img_res.DictNode("SIZENAMES","tdb"),
                new img_res.DictNode("MESSAGE TABLE","tdb"),
                new img_res.DictNode("ACCELERATOR","tdb"),
                new img_res.DictNode("TEXTFILE","tdb"),
                new img_res.DictNode("BITMAP","image"),
                new img_res.DictNode("STRING","tdb"),
                new img_res.DictNode("MANIFEST","tdb"),
                new img_res.DictNode("VERSION","tag"),
                new img_res.DictNode("DIALOG INCLUDE","frm_mag"),
                new img_res.DictNode("DIALOG","frm"),
                new img_res.DictNode("CURSOR","cur"),
                new img_res.DictNode("HTML","htm"),
                new img_res.DictNode("ICON","image"),
                new img_res.DictNode("CURSOR GROUP","group"),
                new img_res.DictNode("ICON GROUP","group")
            );
            _res = new img_dict();
            _res.AddRange(
                new img_dict.DictNode("folder",famfam_silky.folder),
                new img_dict.DictNode("pkg",famfam_silky.package),
                new img_dict.DictNode("pkg_",famfam_silky.package_green),
                new img_dict.DictNode("application",famfam_silky.application),
                new img_dict.DictNode("brick",famfam_silky.brick),
                new img_dict.DictNode("group",famfam_silky.sitemap_color),
                new img_dict.DictNode("table",famfam_silky.table),
                new img_dict.DictNode("style",famfam_silky.style),
                new img_dict.DictNode("font",famfam_silky.font),
                new img_dict.DictNode("image",famfam_silky.picture),
                new img_dict.DictNode("tag",famfam_silky.tag_blue),
                new img_dict.DictNode("field",famfam_silky.textfield),
                new img_dict.DictNode("color",famfam_silky.color_swatch),
                new img_dict.DictNode("cbodata",famfam_silky.picture_empty),
                new img_dict.DictNode("tdb",famfam_silky.page_white_database),
                new img_dict.DictNode("frm_mag",famfam_silky.application_form_magnify),
                new img_dict.DictNode("frm",famfam_silky.application_form),
                new img_dict.DictNode("cur",famfam_silky.cursor),
                new img_dict.DictNode("htm",famfam_silky.html),
                new img_dict.DictNode("nitem",famfam_silky.note),
                new img_dict.DictNode("imgs",famfam_silky.pictures)
            );
        }

//		SearchControlManager scmanager;
        public ui_fx_manager(ui_fx_frm frm) : base(frm,true)
        {
            InitializeDictionaries();
            treeman = new treeview_node_mover(Client.tvRes,Client.tsUp,Client.tsDown);
            Client.tvProperties.ImageList = Client.tvRes.ImageList = _res.ToImageList();
            Client.Finder.manager.QueryObject = Client.richTextBox1;
        }
    }
}
