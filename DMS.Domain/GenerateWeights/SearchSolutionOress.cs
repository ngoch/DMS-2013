using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace DMS.Domain.GenerateWeights
{
    public class Rpoly
    {

        [DllImport("rpoly.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SearchSolutionsDll")]
        public static extern double SearchSolutionsDll(double alfa, int weightAmountN, double precession, IntPtr mainResault);
    }

    public class SearchSolutionOress
    {
        public static List<double> GenerateWeight(double alfa, int weightAmountN, double precession = 0.00001)
        {
            var mass = new double[weightAmountN];
            IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(mass[0]) * weightAmountN);

            Rpoly.SearchSolutionsDll(alfa, weightAmountN, precession, pnt);

            Marshal.Copy(pnt, mass, 0, mass.Length);

            Marshal.FreeHGlobal(pnt);

            return new List<double>(mass).Select(t => Math.Round(t, 5)).ToList();
        }
    }
}
