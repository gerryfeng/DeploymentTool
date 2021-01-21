using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.Utils
{
    public class CommonUtils
    {

		//获取svg文件的宽度和高度 当svg文件中没有宽度和高度属性默认返回0,0
		public static void getSvgWH(string svgStr, out string width, out string height)
		{
			int startSvgIndex = svgStr.IndexOf("<svg");
			int end = (svgStr.Substring(startSvgIndex, svgStr.Length - startSvgIndex)).ToString().IndexOf(">");
			string fileString = svgStr.Substring(startSvgIndex, end + 1); // 读取文件内容
			var reg_width = new Regex("[\\s\\S]*svg[\\s\\S]*width=\"([1-9]\\d*\\.\\d*|0\\.\\d*[1-9]\\d*|[1-9]\\d*)[a-zA-z]*\"[\\s\\S.]*");
			var reg_height = new Regex("[\\s\\S]*svg[\\s\\S]*height=\"([1-9]\\d*\\.\\d*|0\\.\\d*[1-9]\\d*|[1-9]\\d*)[a-zA-z]*\"[\\s\\S.]*");
			width = reg_width.Replace(fileString, "$1");
			height = reg_height.Replace(fileString, "$1");
		}

	}
}
