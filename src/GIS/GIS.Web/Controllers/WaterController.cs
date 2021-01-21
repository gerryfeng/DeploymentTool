// GIS.Web.Controllers.WaterController
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.InteropServices;
using System.Text;

[ApiController]
[Route("[controller]")]
public class WaterController : ControllerBase
{
	[DllImport("pandaAnalysis.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool hdyrSimulation(string uri);

	[HttpGet("HdyrSimulation")]
	public string HdyrSimulation([FromQuery] string uri)
	{
		string res = string.Empty;
		try
		{
			bool msg = hdyrSimulation(uri);
			return "success";
		}
		catch (Exception e)
		{
			return "false  " + e.ToString();
		}
	}

	[DllImport("pandaAnalysis.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool qualitySimulation(string uri);

	[HttpGet("QualitySimulation")]
	public string QualitySimulation([FromQuery] string uri)
	{
		string res = string.Empty;
		try
		{
			bool msg = qualitySimulation(uri);
			return "success";
		}
		catch (Exception e)
		{
			return "false  " + e.ToString();
		}
	}

	[DllImport("pandaAnalysis.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool trackingSimulation(string uri, string sN, int hours, StringBuilder result);

	[HttpGet("TrackingSimulation")]
	public string TrackingSimulation([FromQuery] string uri, [FromQuery] string sN, [FromQuery] string hours)
	{
		string res = string.Empty;
		try
		{
			StringBuilder buf = new StringBuilder(131072);
			bool msg = trackingSimulation(uri, sN, int.Parse(hours), buf);
			res = buf.ToString();
		}
		catch (Exception e)
		{
			res = "false  " + e.ToString();
		}
		return "success," + res;
	}

	[DllImport("pandaAnalysis.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool getDataByInterval(string uri, string date, string interval);

	[HttpGet("GetDataByInterval")]
	public string GetDataByInterval([FromQuery] string uri, [FromQuery] string date, [FromQuery] string interval)
	{
		string res = string.Empty;
		try
		{
			bool msg = getDataByInterval(uri, date, interval);
			return "success";
		}
		catch (Exception e)
		{
			return "false  " + e.ToString();
		}
	}

	[DllImport("pandaAnalysis.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool upstreamTracking(string uri, string sN, StringBuilder result);

	[HttpGet("UpstreamTracking")]
	public string UpstreamTracking([FromQuery] string uri, [FromQuery] string sN)
	{
		string res = string.Empty;
		try
		{
			StringBuilder buf = new StringBuilder(524288);
			bool msg = upstreamTracking(uri, sN, buf);
			res = buf.ToString();
		}
		catch (Exception e)
		{
			res = "false  " + e.ToString();
		}
		return "success," + res;
	}

	[DllImport("pandaAnalysis.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool downstreamTracking(string uri, string sN, StringBuilder result);

	[HttpGet("DownstreamTracking")]
	public string DownstreamTracking([FromQuery] string uri, [FromQuery] string sN)
	{
		string res = string.Empty;
		try
		{
			StringBuilder buf = new StringBuilder(131072);
			bool msg = downstreamTracking(uri, sN, buf);
			res = buf.ToString();
		}
		catch (Exception e)
		{
			res = "false  " + e.ToString();
		}
		return "success," + res;
	}

	[DllImport("pandaAnalysis.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool projSimulation(string uri, string projCode, string time);

	[HttpGet("ProjSimulation")]
	public string ProjSimulation([FromQuery] string uri, [FromQuery] string projCode, [FromQuery] string time)
	{
		string res;
		try
		{
			res = projSimulation(uri, projCode, time).ToString();
		}
		catch (Exception e)
		{
			res = "false  " + e.ToString();
		}
		return "success," + res;
	}

	[DllImport("pandaAnalysis.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool optimalSchedulingSimulation(string uri, string condition, int timeInterval, StringBuilder result);

	[HttpGet("OptimalSchedulingSimulation")]
	public string OptimalSchedulingSimulation([FromQuery] string uri, [FromQuery] string condition, [FromQuery] int timeInterval)
	{
		string res = string.Empty;
		try
		{
			StringBuilder buf = new StringBuilder(131072);
			optimalSchedulingSimulation(uri, condition, timeInterval, buf);
			res = buf.ToString();
		}
		catch (Exception e)
		{
			res = "false  " + e.ToString();
		}
		return "success," + res;
	}

	[DllImport("pandaAnalysis.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool residualChlorineAnalysis(string uri, string startTime, string endTime, string conditionMap,string error);

	[HttpGet("ResidualChlorineAnalysis")]
	public string ResidualChlorineAnalysis([FromQuery] string uri, [FromQuery] string startTime, [FromQuery] string endTime, [FromQuery] string conditionMap)
	{
		string res = string.Empty;
		try
		{
			StringBuilder buf = new StringBuilder(131072);
			string error = string.Empty;
			residualChlorineAnalysis(uri, startTime, endTime, conditionMap, error);
			res = buf.ToString();
		}
		catch (Exception e)
		{
			res = "false  " + e.ToString();
		}
		return res;
	}
}
