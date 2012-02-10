using System;
using System.Collections;

namespace MyClasses
{
	/// <summary>
	/// Summary description for mach2mach.
	/// </summary>
	public class mach2mach
	{
      static Hashtable counters = new Hashtable();
      static Hashtable ips = new Hashtable();


      public static string GetSourceIP(string key)
      {
         string mac = GetSource(key);

         string ip = mac;
         try
         {
            ip = (string)ips[mac];
         }
         catch
         {
         }
         if (ip == null)
         {
            ip = mac;
         }
         return ip;
      }
      public static string GetDestinationIP(string key)
      {
         string mac = GetDestination(key);

         string ip = mac;
         try
         {
            ip = (string)ips[mac];
         }
         catch
         {
         }
         if (ip == null)
         {
            ip = mac;
         }
         return ip;
      }
      public static string GetSource(string key)
      {
         return key.Substring(0, key.IndexOf("|"));
      }

      public static void Clear()
      {
         counters.Clear();
      }

      public static string GetDestination(string key)
      {
         return key.Substring(key.IndexOf("|")+1);
      }

      static string MakeKey(string s1, string s2)
      {
         return s1 + "|" + s2;
      }

      public static Hashtable Stats
      {
         get
         {
            return counters;
         }
      }

      public static void Add(string mac, string ip)
      {
         if (ips.Contains(mac))
         {
         }
         else
         {
            ips.Add(mac, ip);
         }
      }

      public static void Add(string source, string dest, long size)
      {
         long total = 0;
         string key = MakeKey(source, dest);
         try
         {
            total = (long)counters[key];
         }
         catch
         {
            counters.Add(key, total);
         }

         total += size;

         counters[key] = total;
      }
	}
}
