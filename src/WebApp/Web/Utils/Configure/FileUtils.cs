using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Svg;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.Utils
{
    public class FileUtils
    {

        public static string FileStreamReadFile(string filePath)
        {
            byte[] data = new byte[100];
            char[] charData = new char[100];
            FileStream file = new FileStream(filePath, FileMode.Open);
            //文件指针指向0位置
            file.Seek(0, SeekOrigin.Begin);
            //读入两百个字节
            file.Read(data, 0, (int)file.Length);
            //提取字节数组
            Decoder dec = Encoding.UTF8.GetDecoder();
            dec.GetChars(data, 0, data.Length, charData, 0);
            return Convert.ToString(charData);
        }


        /// <summary>
        ///  SVG 转 图片
        /// </summary>
        /// <param name="pngPath">图片保存路径</param>
        /// <param name="SvgStr">Svg文本</param>
        /// <returns>生成图片路径</returns>
        public static string SvgToPicture(string pngPath,string SvgStr) 
        {
            string width = "0";
            string height = "0";

            Stopwatch sw = new Stopwatch();
            sw.Start();
            CommonUtils.getSvgWH(SvgStr, out width, out height);
            sw.Stop();
            Console.WriteLine($" 宽{width} 高{height} 耗时:{sw.ElapsedMilliseconds}ms ");

            sw.Restart();
            using (Bitmap bitmap = new Bitmap(Convert.ToInt32(width), Convert.ToInt32(height)))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    SvgDocument document = SvgDocument.FromSvg<SvgDocument>(SvgStr);
                    ISvgRenderer renderer = SvgRenderer.FromGraphics(g);
                    document.Width = Convert.ToInt32(width);
                    document.Height = Convert.ToInt32(height);
                    document.Draw(renderer);
                    //释放资源以避免 GDI+ 问题
                    g.Dispose();
                }
                bitmap.Save(pngPath, ImageFormat.Png);
                //释放资源以避免 GDI+ 问题
                bitmap.Dispose();
            }

            sw.Stop();
            Console.WriteLine($"  耗时:{sw.ElapsedMilliseconds}ms ");
            return pngPath;
        }


        /// <summary>
        /// 将图片以二进制流
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] SaveImage(String path)
        {
            byte[] imgBytesIn = new byte[0];
            if (File.Exists(path)) 
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite); //将图片以文件流的形式进行保存
                BinaryReader br = new BinaryReader(fs);
                imgBytesIn = br.ReadBytes((int)fs.Length); //将流读入到字节数组中
                fs.Close();
                return imgBytesIn;
            }
            return imgBytesIn;
        }


        /// <summary>
        /// 删除文件目录
        /// </summary>
        /// <param name="dir"></param>
        public static void DeleteFolder(string dir)
        {
            if (System.IO.Directory.Exists(dir))
            {
                string[] fileSystemEntries = System.IO.Directory.GetFileSystemEntries(dir);
                for (int i = 0; i < fileSystemEntries.Length; i++)
                {
                    string file = fileSystemEntries[i];
                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }
                    else
                    {
                        DeleteFolder(file);
                    }
                }
                System.IO.Directory.Delete(dir);
            }
        }


        /// <summary>
        /// 下载本地文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static async Task<Stream> downloadFile(string filePath,HttpContext context)
        {
            context.Response.ContentType = "application/octet-stream;charset=UTF-8";
            context.Response.Headers.Add("Content-Disposition", "attachment; filename=" + Path.GetFileNameWithoutExtension(filePath) + Path.GetExtension(filePath));
            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }
    }
}
