﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace SomeDemo
{
    class Program
    {
        class A
        {
            public virtual void test()
            {
                Console.WriteLine("A");
            }
        }
        class B : A
        {
            public override void test()
            {
                Console.WriteLine("B");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                var c = "".FirstOrDefault();
                var s = new Solution();
                int t;
                t = s.CalculateMinimumHP(new int[][] { new int[] { -2, -1000, 1000 }, new int[] { -1000, -1, 1 }, new int[] { 10, 30, -5 } });
                Assert(t, 7);
                t = s.CalculateMinimumHP(new int[][] { new int[] { -2, -3, 3 }, new int[] { -5, -10, 1 }, new int[] { 10, 30, -5 } });
                Assert(t, 7);
                t = s.CalculateMinimumHP(new int[][] { new int[] { 1, 2, 3 }, new int[] { 1, 10, 1 }, new int[] { 10, 30, -5 } });
                Assert(t, 1);
                t = s.CalculateMinimumHP(new int[][] { new int[] { 1, 2, 3 }, new int[] { 1, 10, 1 }, new int[] { 10, 30, 5 } });
                Assert(t, 1);
                t = s.CalculateMinimumHP(new int[][] { new int[] { 1 } });
                Assert(t, 1);
                var map =
new int[][] { new int[] { 2, -8, -79, -88, -12, -87, -5, -56, -55, -42, 18, -91, 1, -30, -36, 42, -96, -26, -17, -69, 38, 18, 44, -58, -33, 20, -45, -11, 11, 15, -40, -92, -62, -51, -23, 20, -86, -2, -90, -64, -100, -42, -16, -55, 29, -62, -81, -60, 7, -5, 31, -7, 40, 19, -53, -81, -77, 42, -87, 37, -43, 37, -50, -21, -86, -28, 13, -18, -65, -76 }, new int[] { -67, -23, -62, 45, -94, -1, -95, -66, -41, 37, 33, -96, -95, -17, 12, 30, -4, 40, -40, -89, -89, -25, -62, 10, -19, -53, -36, 38, -21, 1, -41, -81, -62, 3, -96, -17, -75, -81, 37, 32, -9, -80, -41, -13, -58, 1, 40, -13, -85, -78, -67, -36, -7, 48, -16, 2, -69, -85, 9, 15, -91, -32, -16, -84, -9, -31, -62, 35, -11, 28 }, new int[] { 39, -28, 1, -31, -4, -39, -64, -86, -68, -72, -68, 21, -33, -73, 37, -39, 2, -59, -71, -17, -60, 4, -16, -92, -15, 10, -99, -37, 21, -70, 31, -10, -9, -45, 6, 26, 8, 30, 13, -72, 5, 37, -94, 35, 9, 36, -96, 47, -61, 15, -22, -60, -96, -94, -60, 43, -48, -79, 19, 24, -40, 33, -18, -33, 50, 42, -42, -6, -59, -17 }, new int[] { -95, -40, -96, 42, -49, -3, 6, -47, -38, 31, -25, -61, -18, -52, -80, -55, 29, 27, 22, 6, 29, -89, -9, 14, -77, -26, -2, -7, -2, -64, -100, 40, -52, -15, -76, 13, -27, -83, -70, 13, -62, -54, -92, -71, -65, -18, 26, 37, 0, -58, 4, 43, -5, -33, -47, -21, -65, -58, 21, 2, -67, -62, -32, 30, -4, -46, 18, 21, 2, -5 }, new int[] { -5, 34, 41, 11, 45, -46, -86, 31, -57, 42, -92, 43, -37, -9, 42, -29, -3, 41, -71, 13, -8, 37, -36, 23, 17, -74, -12, -55, -18, -17, -13, -76, -18, -90, -5, 14, 7, -82, -19, -16, 44, -96, -88, 37, -98, 8, 17, 9, -2, -29, 11, -39, -49, -95, 20, -33, -37, -42, 42, 26, -28, -21, -44, -9, 17, -26, -27, 24, -60, -19 }, new int[] { -95, -73, -88, -4, 32, 7, 20, 19, -17, 36, -81, -91, -6, -74, 20, 47, -24, 15, 40, -5, -28, -5, 23, -30, 6, -97, 49, -12, -57, 21, 1, 11, -64, -32, -95, -33, 10, 50, 47, 41, -11, -51, 22, -84, 39, 10, -36, -72, -27, -60, -19, -51, -11, 37, 2, -62, 22, -66, -61, 29, -50, -94, 48, -23, 18, -37, -92, -92, -4, -97 }, new int[] { 46, 4, -96, -31, 14, -25, -74, -73, -40, -46, 38, -31, 23, -34, 12, 25, 34, 42, -43, -91, 3, 34, -17, -64, 21, -98, 11, -70, -36, -66, 2, -19, 30, -88, 43, -62, 33, -75, -11, 45, -95, -65, -25, 27, -35, -57, -81, 2, 10, 33, -46, -40, -4, -15, -94, 48, -95, 24, -87, -12, 12, -70, 35, 42, -69, 19, -74, -14, -81, 2 }, new int[] { 32, 17, -79, -89, 25, 19, -98, -60, -81, -47, -8, -61, -41, -33, -33, -81, 15, -75, 8, -99, -29, -75, -23, -54, 27, 41, -23, -70, 19, -60, -91, -60, 34, 42, -35, 25, -61, -46, 41, 44, -27, -57, -24, -87, 4, -55, -40, -74, -20, 44, 37, 14, -48, -89, -26, -15, -40, -38, 14, 22, 24, 47, -62, -65, -73, -86, 50, -62, 24, -53 }, new int[] { -24, 10, 32, 7, -21, 44, -23, 5, -98, 40, -21, -4, -63, 38, -89, 26, -62, -98, -87, -67, 7, -50, -84, 6, -12, -10, -25, 7, -96, 0, -78, -36, 6, 22, -83, 39, -94, -15, -63, -70, -4, -91, -96, -73, -11, 33, 11, -24, -11, -64, 7, 49, 7, -55, -91, -88, -100, 45, -48, 31, 28, -97, -88, -96, -14, -22, -41, -97, 6, 31 }, new int[] { -12, -9, -71, -55, -40, -66, -21, 48, 30, 38, -64, -13, -22, 9, -61, -41, 12, -26, -92, -55, -33, -67, -59, -31, -77, 19, 13, -28, 8, -13, -13, -19, -31, -87, 2, -93, -95, 14, 6, 34, -38, -88, 48, 38, -52, -92, -62, -76, -55, 45, 50, 24, -76, -54, -70, -35, 35, -90, -99, 16, 12, 39, 21, -88, -68, 6, 6, -2, -72, 26 }, new int[] { -58, 5, -60, 16, -84, -67, -28, -11, -63, -49, -4, -41, -99, 3, -1, 47, 12, -69, -69, -20, -78, -21, 20, -67, 6, 14, -86, -35, 7, 7, 7, 3, 10, -18, 33, -14, 36, -75, -89, -90, -29, -3, -89, 18, 48, -61, 48, 25, -17, -28, -46, 44, 5, 48, -10, -21, -4, 49, -57, 37, -16, 28, 22, -95, 39, 7, -82, 13, -68, 23 }, new int[] { -77, -64, -34, -54, -25, -19, -63, -57, -33, -76, -89, -21, -70, -62, -97, 50, -14, -55, -27, -16, -17, 7, 29, 9, -95, -77, 45, -71, -12, 27, -68, -62, -66, -100, -60, -86, -15, 38, 19, -50, 43, -9, 47, -97, -96, -31, -51, 48, -24, 2, 13, -25, -8, -44, -34, -100, -14, -5, -4, -69, 25, -63, -70, -99, -9, -68, -88, -24, 5, -69 }, new int[] { 25, -88, -91, -26, -73, -52, -81, -96, -53, 2, -35, -77, -1, 2, 16, 10, -14, 15, 42, -52, -42, -48, -68, 21, 3, -26, -75, 45, 12, -82, 25, -29, 15, 18, -37, 4, 41, -26, -98, -94, -74, -5, -15, 11, 11, -68, -94, -100, -100, 29, -83, -99, -75, -9, -62, -31, 23, -47, -68, -8, 8, -100, -1, -76, -17, -58, 36, -84, -32, -93 }, new int[] { -81, 37, 19, -5, 18, 15, -34, -29, -84, -35, -67, -64, -57, -99, 46, 26, -38, -37, -79, 0, -6, 32, 50, 37, -63, 27, -56, 11, -3, -66, -72, 34, 13, -4, 30, -82, 32, -71, -35, -30, 10, -48, -93, -94, -92, -4, -21, -34, -67, -80, -98, -28, 32, -86, -22, 6, 46, -75, -40, -100, -7, 11, -44, -12, -36, -24, 46, -1, 26, -20 }, new int[] { -81, -20, -54, -75, -78, 23, -76, -90, 46, -20, -5, 30, -59, -37, -82, -68, 36, 8, 50, -72, 48, -97, -93, -10, -31, -91, -81, -59, 27, -47, -65, -75, -19, 26, 12, 41, 16, -30, 33, 9, -28, -23, 45, -32, -68, 39, -24, -89, -47, -41, -71, -96, -45, -34, -43, -23, 39, -32, -99, -19, 46, 30, -89, -8, -65, -94, 42, 8, -14, -50 }, new int[] { -49, -64, 20, -6, -82, -30, -99, -79, -27, -2, -17, 30, -14, 47, -3, -47, 31, 2, -28, -7, -83, -56, -43, 11, -46, -85, -17, -30, -47, -84, -88, -36, 42, -71, -39, -28, 8, -78, -39, 49, 8, 11, 37, 6, -38, 33, -36, -36, -37, -44, -77, 41, 45, -47, -63, -58, -28, -31, -97, 23, -94, -72, 35, -39, -2, 27, -87, 3, 13, -66 }, new int[] { 49, 27, -43, -84, 27, -93, 38, 25, 18, 43, 48, 49, -35, -51, 28, 27, 2, 29, 0, -47, -30, -25, -90, -92, -93, 0, -73, -73, 0, -62, -73, 12, -15, -40, -50, 11, -97, -74, 42, -55, -27, -7, 49, -32, -30, -6, -54, -88, -73, 43, -46, -29, -50, -50, -11, 5, 23, 6, 12, 20, -59, 47, -98, -77, 47, -5, -17, 23, -31, -14 }, new int[] { -28, 23, -90, -47, 41, 32, -38, 32, -56, -29, -20, -34, -79, 41, 6, -52, 41, -43, -24, -55, -81, 3, -42, 6, 26, 31, -64, 35, 7, -85, -38, 14, -29, 8, -88, 26, -100, 9, -11, -79, -59, 2, 38, 47, 23, 39, 46, -65, -62, -61, 1, 43, -58, -90, 33, 36, -30, 38, -11, -37, 19, 41, -2, -94, -8, 20, -38, -82, -73, 28 }, new int[] { -54, -64, 24, -40, -33, 34, 36, 3, -56, -36, 23, -91, 50, 16, 27, -26, 25, 41, -15, -64, -30, -53, 50, -46, 11, -89, -98, 11, -81, -66, -76, -40, 12, 4, -21, -67, 48, -86, -43, 22, -70, 46, 48, -82, -94, -13, 0, 29, 29, 36, -19, -1, -55, 48, -63, 47, -30, -81, 1, -43, -83, 16, 12, 48, 47, -51, -4, 44, 16, -86 }, new int[] { -63, 31, 1, -65, -78, 42, -14, -99, -77, -62, 27, -51, 46, -58, 40, 15, -19, 45, 10, 0, -67, 42, -86, -100, -40, 30, -75, 0, -82, 10, -14, -43, 26, -26, -97, -31, -68, -76, 13, -85, 35, -60, -82, -67, -99, 12, -22, 8, 21, -93, -70, 48, 36, -57, -57, -91, 8, -32, -60, 28, -73, -59, -72, -69, -32, 33, 6, -8, -45, 35 }, new int[] { 18, -51, -21, 48, -18, 22, -46, -52, -55, -30, 27, -88, -29, -64, 22, -34, -62, -23, -60, -76, -41, -64, -82, 15, 18, -10, -37, -97, 38, -50, 12, -28, -48, -57, -53, -48, -81, -75, -85, -12, 38, -87, -72, -82, -59, -3, 25, -46, 9, -95, -28, -79, -67, 14, -71, -18, 14, 0, -65, -37, 26, 30, 35, -33, -37, 1, 33, -70, -28, 47 }, new int[] { -78, -43, -64, -91, -78, 35, -8, 38, -79, -15, -11, 17, 11, -78, -32, -14, -15, -64, 18, -90, 32, -48, 38, 33, -19, 32, -23, -29, -68, -23, -53, -58, -20, 1, -22, -51, -29, 1, -60, -91, 8, -15, -12, -71, -16, -23, 3, -84, -89, 15, 14, 18, -99, -27, -70, -18, 29, -14, 15, 0, -49, 0, 17, -97, -23, -30, -49, -46, -52, 41 }, new int[] { -34, -39, 42, 34, -54, 43, 32, 49, 46, -23, 24, 24, -1, -21, -12, -15, -3, -72, -61, -75, -53, -49, -47, -64, 40, -56, -63, -95, -52, 3, -26, -12, -58, 49, 5, 21, -47, 32, -92, -46, -10, 28, -90, -83, 46, 9, -49, -19, 32, -41, 34, 29, 0, -98, -40, 26, -30, -10, -51, 20, -54, 33, 16, -24, -52, 44, 49, 15, -58, -56 }, new int[] { 31, -24, -28, -5, 40, 32, -74, -1, 28, -81, 8, -96, 8, -22, -27, 32, 22, -24, 16, 40, -68, -50, -49, -84, 25, -55, -7, -100, -77, 25, -40, -6, -68, -90, -88, -74, -77, -24, -17, 6, -72, 46, 23, -52, 40, -71, -41, 21, 28, -29, 31, -71, 16, -83, 42, 25, -3, -84, 33, -66, -33, -24, -65, -39, -5, 21, -36, -87, 3, 38 }, new int[] { -98, -64, 38, 45, -90, 44, -63, 20, -44, 32, -4, 0, -22, -39, -8, 19, -20, -58, 5, 1, 32, -92, -36, 25, -82, 45, -55, 23, -50, -89, -81, -33, 16, -18, -7, 21, 40, -62, -16, -84, -19, -37, -66, 48, -30, 30, -8, 1, -70, -6, -65, 15, -11, -66, -71, -26, -15, 48, -80, -6, -41, 29, -80, -82, -6, -73, -56, -38, 44, 23 }, new int[] { 14, -29, 19, -13, -93, -33, -29, -16, 21, -51, 8, 6, -63, 24, -23, 14, 47, -84, -27, -11, -56, -65, 0, -11, -28, -55, 11, -67, 18, -6, -87, -34, -44, -24, -77, -34, -22, -8, 36, -11, -89, -75, -43, -92, -94, -73, 41, -27, -63, 30, -37, -82, 22, -60, -92, -58, 11, -27, -98, -68, 45, -3, 50, -83, -45, 6, 12, -48, -16, 27 }, new int[] { 47, -61, 2, 7, -84, 26, -67, -32, 33, -100, -66, -64, -25, 25, -4, -51, -69, -92, 39, 6, -82, -36, -14, -59, -40, -48, -30, -42, 5, -72, 33, -85, -65, 9, 45, -11, -28, 32, -19, -71, -51, -73, -34, -21, -35, -52, -27, -76, 40, 44, 12, -18, -14, 28, -31, 19, -20, -84, -28, -32, -75, -84, 21, 44, 3, -70, -59, -6, -27, -39 }, new int[] { -65, -41, -22, 29, -31, -62, -26, -40, -100, -40, 48, -34, 44, -20, 20, -29, -65, 2, -81, 0, -29, -64, -59, 38, 30, -58, 31, -87, 7, 37, -95, 28, 48, 40, -81, 25, -81, -96, 4, 15, 15, -96, 14, 24, 20, -35, -37, -98, 5, -82, 34, -39, -43, -63, 35, 1, -10, -83, 34, -21, -78, -65, -44, 48, -32, -5, -1, -18, -97, 28 }, new int[] { 11, 34, 47, 21, -69, 17, -38, -4, -25, -89, -64, 50, 7, 4, 44, 44, -5, -16, -99, 31, 9, -57, 11, -100, 41, -93, 21, -20, 28, -39, -23, -6, -34, -61, -24, 31, -76, -66, -54, 34, 2, -85, -2, 45, 28, -51, -48, -67, -20, -83, -12, -55, -83, -2, -86, -44, -80, -9, 4, 43, -98, -24, -82, 34, -27, -63, -9, -12, -94, -15 }, new int[] { 20, -49, -91, -71, 37, 39, -50, -93, -93, -94, 13, 32, -99, -26, -25, -79, -10, -18, 27, 38, 13, 18, -55, -37, -66, 10, -61, 32, 49, -27, -60, -69, -92, -54, -96, -89, -40, -5, -29, 5, -85, 20, -22, -5, -49, -31, -83, 28, -62, -92, -2, 28, -24, 20, -12, -92, -30, -92, -76, 46, 22, -55, 28, -81, -59, 23, -22, -3, 36, 20 }, new int[] { 31, -79, 31, -22, -47, -47, -42, -10, -32, -38, 27, 2, -39, -28, -33, 4, -54, -80, -89, 24, 23, -1, 30, -60, -31, -35, 0, -37, -46, -33, 33, 44, 7, 10, -27, -98, 6, 22, -48, 14, -72, -69, 42, 23, 6, -50, -84, -62, -15, -69, 4, 32, 16, -61, 48, 42, -41, -8, -82, -62, -79, -15, -88, -11, -61, -96, -63, -95, 24, -49 }, new int[] { 5, 9, -93, -50, -42, -54, 50, 17, 22, 12, -11, -5, -35, -7, -65, -71, -4, 27, 42, -13, -100, -21, -7, 14, -86, 16, -42, 33, -54, 24, -44, -1, -89, 42, -34, -99, -74, -15, -70, -40, -69, -41, -17, 47, 48, 33, -100, -64, -39, 47, -75, -1, -97, -45, -71, -48, -80, -86, 14, 6, -97, -80, -75, -59, -3, -1, -66, -93, -65, -14 }, new int[] { -67, -57, -41, 41, -54, 10, -25, -78, 7, 21, -2, 27, 32, -68, 35, -61, 46, -80, -89, -20, -87, -1, -97, -81, 4, 11, -56, -31, -38, 15, -70, -11, -15, -9, -76, 1, 40, -72, -66, -52, 30, -97, 15, 22, 41, -57, 15, 13, -53, -71, -50, -39, 18, -18, 6, -20, -41, 32, -16, 22, -1, -47, -82, -2, -92, -93, -6, 28, -60, -100 }, new int[] { -88, 16, -14, -3, -12, 16, -94, -49, 3, -6, 8, -45, -36, -81, 21, -37, 38, -53, -54, -78, -99, 38, -60, 10, 22, 10, 20, 43, -27, -10, 24, -15, -3, 28, -51, -93, 32, -9, -68, -22, 34, -91, -34, -7, -48, -6, -49, -13, -54, -7, -56, -79, -5, 36, -58, -36, -8, 10, -20, -72, -82, 13, -70, -98, 39, -88, -62, -25, 19, -62 }, new int[] { -16, 50, -27, -22, 32, -30, 50, -88, 4, -71, -14, -39, -52, -16, -43, -62, 20, 11, -73, -10, 13, 31, -71, -68, -79, 21, 5, -55, 48, 33, -36, 35, -14, -65, 37, 29, -54, 15, 40, -3, -68, -11, -48, -25, 33, -78, -41, -81, -48, -63, -100, -56, -70, 3, 31, -20, -80, 17, -95, 14, -80, 11, -31, -38, -54, -17, 0, -93, -2, 1 }, new int[] { -16, -16, -36, 0, -78, -8, 22, -90, 21, -46, 26, 42, 16, -54, -72, -27, -69, -33, -82, -41, 29, 39, -46, -100, -78, -80, -85, -81, 15, -66, -65, 45, -21, 9, 16, -42, 12, -62, 50, -71, -44, -44, -85, -68, 8, -52, -77, 4, -19, -29, 50, 39, -73, -92, 2, -88, 31, -47, -12, -31, -33, -6, -75, -71, 18, -61, -43, 25, -73, 33 }, new int[] { -40, -74, -34, -81, 8, 1, -52, -65, 13, -10, 48, -31, 38, -26, -33, 7, 31, 38, -70, -93, -34, -85, -4, 7, -9, -23, -97, -18, -13, -12, -11, -63, -25, -6, -42, -44, 38, -26, -28, -52, -7, -43, -85, -76, 31, 37, 29, 47, -83, -55, -8, -32, 8, 49, 5, -49, -18, 5, -59, -27, -37, -60, 36, -27, -45, -87, -8, -74, -92, -49 }, new int[] { -18, -35, -84, 28, 15, -99, -37, -96, -29, 44, 11, -50, -78, -56, 41, -42, -13, 14, 8, 14, -96, 8, -52, -33, 41, -4, -65, -65, -79, -18, -73, 1, -69, 1, -82, 33, -33, -10, 19, 2, -51, 20, -19, -30, -28, -40, 38, 35, 10, -3, 44, -29, 22, -95, -2, -97, -1, -16, 29, -2, -7, -92, -38, -19, -88, -16, 28, -54, -94, -65 }, new int[] { -75, -38, -79, -54, 11, -45, 11, 23, 15, 24, -39, 1, 50, -61, -44, -83, 13, 7, -2, 0, 38, 16, -90, 40, -42, 34, 46, -62, 37, -90, 34, -87, -2, -86, -53, 7, -33, 17, -34, -93, 31, -52, -63, 30, 49, -71, -84, -82, 23, 39, 45, 22, -90, 24, -99, -75, -32, -31, -73, 10, -59, -34, -40, 26, -1, -17, -1, 31, 43, -32 }, new int[] { -74, -98, -55, -88, -76, -62, -48, 2, -50, 39, -6, -34, 39, -37, -52, -8, -23, -66, -23, -31, -38, 44, 38, -75, -57, 21, 15, -25, -68, -20, -16, -15, -78, 36, -69, -21, -72, 8, -63, -92, -75, -5, -98, -96, -67, -88, -91, 1, -20, -43, -81, -68, 49, -83, 35, -3, -2, 3, -84, -63, 46, 30, -63, -36, 14, 28, -68, -33, 8, -33 }, new int[] { 7, -89, 34, -58, -15, 27, -37, -1, -83, -28, -95, 13, -50, -100, 34, 41, -88, -61, -37, 2, -38, -97, -88, -14, -39, -58, 17, -95, 40, -93, -33, 15, -83, -13, -32, -91, -77, -44, -93, 1, 3, 26, -73, 41, -63, -24, 1, -30, -84, 18, -5, -3, 13, 30, 45, 42, -81, -91, -75, -63, -66, 24, -22, 40, 30, 37, -2, -97, -43, -4 }, new int[] { 50, 3, 17, -6, -11, -67, -48, 46, -22, -74, -17, -41, -24, -60, 35, 10, -85, -48, 14, -36, 4, -42, -88, -10, 38, -67, -98, -70, -52, -36, -72, -66, -77, -51, -98, -19, -50, -77, 47, 27, -80, -28, -4, 31, 39, -28, 27, -16, 11, -7, -13, 41, -15, -60, 16, 1, -66, -34, 30, 45, -41, 29, -23, -89, -96, 9, -75, -57, -17, 19 }, new int[] { 20, -18, -68, -61, -93, 48, -31, -29, 9, -100, -27, -9, -81, -45, -44, -2, 7, 38, -27, 15, 41, -66, 25, -49, 1, 36, -66, -30, -53, -67, -75, 12, 5, -2, -96, 13, -27, -36, 3, 1, -65, -47, -86, -65, 40, 19, 36, -16, 15, -49, -30, -28, -56, -57, 1, -28, -82, -64, 8, 40, -87, -56, 45, -37, -15, -72, -42, 44, -66, -34 }, new int[] { -75, 40, -87, -89, -27, 50, -20, -1, 27, -41, -90, -72, 38, -26, 43, -84, -4, -1, 38, 39, -8, -82, -99, 7, -56, -55, -70, 10, -27, 15, -56, 50, -69, -48, -44, 7, -83, -68, -27, -24, -22, -34, 20, 26, -66, -58, -7, -87, 29, 33, -15, 18, -47, -70, -22, 35, 3, -87, -14, 8, -75, 41, 26, 38, -83, 42, 24, 20, 42, 8 }, new int[] { 16, -11, -22, 45, 13, -9, 43, 15, -100, -16, -65, -81, -36, 42, 26, -13, -64, 28, 16, -52, 4, -87, 50, 1, -9, -62, 27, -42, -65, -21, -53, -53, -28, -78, -6, -95, -18, -76, 27, -65, 33, 33, -99, -27, 28, -2, -80, -63, -9, -89, -20, -49, -38, 43, 11, -27, -63, -62, -42, -33, -96, -39, 16, -79, -53, 18, -8, -84, -55, -2 }, new int[] { -57, 4, -74, 1, -94, -72, -58, -81, -97, 24, -53, 33, -66, -17, -12, -61, -89, -30, 7, -56, 11, -20, 26, 30, 2, -92, 40, 11, 30, -32, -23, -31, -90, -61, -13, 33, -59, -74, 6, -76, 23, 31, -63, 16, -9, -22, 29, 17, 18, -22, -55, -25, -45, -98, -86, -81, -32, -100, -83, -40, -1, -99, -51, -55, -87, -8, 44, -94, 9, -50 }, new int[] { 40, -19, -54, -78, -12, -20, 13, 3, -36, -98, 19, 49, -69, 29, -63, -41, -81, -84, -83, -32, -25, 30, -56, -96, -48, 50, -87, -100, 33, -15, -66, 47, 45, -26, -60, -1, 27, -64, -4, -77, -57, -52, 9, 2, -72, -66, -73, -23, -39, -66, 43, 34, -26, 17, -98, -68, -39, 49, -14, -20, -32, -50, 18, -37, -61, 10, 16, -75, 2, -32 }, new int[] { -29, -13, -75, -3, -9, 49, -77, 10, -65, 18, -97, -63, -14, -10, -65, -26, 17, -53, -49, -68, -46, -65, -47, -5, 15, 22, -26, -40, 24, -89, -12, 27, -60, 11, 20, 8, -4, 32, -47, -62, 2, 9, -85, -40, -18, -80, -56, -12, 42, -59, -97, -68, 2, -4, 48, -12, 50, -17, -45, -100, 20, 7, -13, -22, 20, 26, 48, -52, 13, 16 }, new int[] { -40, -95, -48, -83, -69, -46, -81, -19, -47, -50, 42, -53, 32, -39, -51, -54, -95, 8, -44, -67, -42, -38, 40, 19, 43, 18, 12, -64, -59, 13, 31, 17, 24, -63, -44, 21, -36, -16, -38, -20, -83, -28, 36, -14, 23, -71, 29, 49, -65, 1, 37, 49, 38, 31, -30, -34, 32, 14, -85, 3, -41, -80, -29, -53, -88, 45, 39, -39, -1, 36 }, new int[] { -85, -62, -8, -76, -89, -74, -36, 36, -86, 5, 3, -55, -44, -98, 48, 47, -3, -75, -31, -11, 26, -66, -82, 46, -73, -96, 10, -95, -19, 30, -79, 0, 32, -22, -43, -51, -22, -49, 5, 48, -30, -20, 8, -20, -44, 20, 15, 3, -56, 28, -17, -87, 19, -22, -71, -72, -57, -91, -62, -1, -99, 36, -57, 19, 47, -62, -52, -42, 7, 4 }, new int[] { -24, -8, 47, -83, -3, 29, 25, -28, 9, -13, -57, 3, -5, 40, -16, -81, 39, -89, -56, -56, -85, -34, -17, -95, -63, -20, 1, -93, 31, 12, 15, -70, -46, 43, 16, -3, 26, -50, -23, -77, 18, 10, 33, 30, -8, -6, 37, -97, -73, 32, 21, 19, -30, -28, 14, 5, 36, -78, -85, 36, 21, 15, 22, -32, -11, -45, 21, -58, 24, -68 }, new int[] { -87, -90, 0, -38, 18, 22, -52, 28, -83, 50, -81, -76, 28, -46, 16, -6, -84, -100, -58, -34, 25, 5, 19, -41, -12, -20, -42, -44, -70, -6, -9, -6, 25, -91, -43, -40, -39, -13, -89, -11, 33, 12, -72, -6, -60, -96, -90, 6, 34, 34, -88, 26, 6, -98, -99, -47, -3, 10, -88, -80, -97, 25, 8, -63, 21, 33, 26, 12, -67, 16 }, new int[] { 3, -32, -39, 46, -14, -100, 30, 27, -22, -48, -11, 8, -97, 36, -33, 47, 42, -78, 46, 26, -50, 5, -81, 1, -58, 18, 8, -36, -63, -100, -47, -25, -42, -97, 25, -30, -73, -84, 18, 11, 47, -33, -27, -16, -82, 20, -4, -30, -62, 47, -90, 2, 41, -3, -91, -26, -5, 24, -48, -75, -53, 16, -7, -42, -52, -73, 45, -30, -78, -98 }, new int[] { -80, 12, -48, -80, -64, -42, -70, 28, 46, 16, 11, -10, 20, 24, 30, -37, 2, -3, -41, 4, -47, 6, -33, 28, 35, 27, 33, -4, -91, -87, -13, -62, -72, -43, 48, 9, 20, 21, 24, 36, 27, -10, 34, 42, 13, -61, -54, -30, -15, 10, -99, 45, 39, -13, -18, 25, -49, 23, 47, -79, 20, -28, -94, 16, 19, 43, -94, 4, -35, -40 }, new int[] { -30, -96, -46, -81, -73, 18, -50, 37, 29, -68, -12, -85, 28, -90, 43, -22, -46, -22, 6, 23, -43, -46, -32, -54, 14, 28, -20, 25, -87, -97, 24, -55, 25, -70, -27, 40, -77, 22, 16, -85, -7, -63, -59, -99, -97, 8, 50, -62, 11, -70, -5, -28, -11, -8, 41, -4, 34, -31, -17, 24, -10, 23, -3, -61, -51, -89, 42, 18, 50, -94 }, new int[] { -63, 32, 36, -75, -79, -31, -12, 10, -87, 20, -85, -10, -61, -81, 4, -78, -71, -41, 44, -70, 25, -92, 44, -52, -59, -29, -57, -77, -54, -10, -92, -40, -60, -3, -24, -47, 24, 35, 24, -27, 26, -10, -64, 15, -41, 25, -44, 16, 41, -82, 18, 8, 43, -55, 31, 30, 13, -83, 12, -22, 29, -97, -2, -46, -23, 30, -32, 25, -3, 44 }, new int[] { 50, 11, -49, -5, -25, 4, 12, 27, -90, -27, 48, 16, -67, -58, -22, 48, -8, -85, -39, 29, 8, -7, -22, 18, 41, 20, 30, 12, -37, -18, 7, -89, -5, -66, 23, 5, -87, 6, -44, -6, -63, -42, -21, 18, -60, -98, -77, -56, -2, -21, 35, 2, 5, 29, 36, -49, -82, 5, 24, 49, 11, -37, -80, -51, -8, -21, 11, 21, -70, -79 }, new int[] { -59, -6, -91, 3, -83, 29, 1, -44, -13, -60, -19, -91, -13, -31, -72, 19, -24, -68, 0, -19, -86, -40, 49, -83, -3, 47, 35, -67, 26, -63, 35, -95, -10, -7, -55, 47, -49, -17, -10, 39, -8, -93, 34, -86, 37, -31, -33, -49, -1, -7, -37, -77, 20, -24, -72, 38, -5, -31, -40, -69, -93, -4, -63, -73, -71, -11, -47, 42, 17, -73 }, new int[] { -12, -56, -25, -7, -91, -6, -62, -34, -27, -88, -58, -90, -12, -3, 23, -6, -42, 36, 27, 39, -48, -1, -92, -8, 23, -91, -50, -84, 5, 19, -63, 32, 30, 31, -67, 36, -15, 44, -60, -57, -33, 18, 49, 11, -55, -54, -27, -31, -96, -20, 1, 36, -14, -15, 44, -72, -88, -41, 24, -7, -4, 48, 34, 33, 19, -41, -11, -91, 39, -9 }, new int[] { -98, -47, -87, -97, -82, 15, 9, 13, -56, 35, -7, 50, -70, 34, 27, 3, -24, -72, -63, -56, -95, -60, -59, 32, -29, 31, 49, 43, 40, -75, -54, 3, -87, -84, -37, 46, 30, -5, -74, -36, -76, -91, -40, 28, -20, 26, -78, -27, 2, 44, -24, 14, -15, 29, -86, -55, 24, -80, -24, 10, -53, -98, 50, -63, -61, 25, -90, 24, 24, -92 } };
                var start = DateTime.Now;
                t = s.CalculateMinimumHP(map);
                var e = DateTime.Now;
                var fff = s.CountSmaller(new int[] { 5, 2, 6, 1 });
                t = s.Respace(new string[] { "a", "b" }, "aa");
                Assert(t, 0);
                t = s.Respace(new string[] { "a", "b" }, "ba");
                Assert(t, 0);
                t = s.Respace(new string[] { "her", "self", "ah" }, "aherself");
                Assert(t, 1);
                t = s.Respace(new string[] { "her", "self" }, "aheraselfr");
                Assert(t, 3);
                t = s.Respace(new string[] { "her", "self", "herselfs" }, "herselfs");
                Assert(t, 0);
                t = s.Respace(new string[] { "looked", "just", "like", "her", "brother" }, "jesslookedjustliketimherbrother");
                Assert(t, 7);
                t = s.Respace(new string[] { }, "jesslookedjustliketimherbrother");
                Assert(t, 31);
                t = s.Respace(new string[] { }, "");
                Assert(t, 0);
                t = s.Respace(new string[] { "looked" }, "");
                Assert(t, 0);
                t = s.Respace(new string[] { "a", "b", "c", "d", "f" }, "abcdefg");
                Assert(t, 2);
                t = s.Respace(new string[] { "ioxxoooooxoiooixxoixixxioooxioixixooooiiixoxioioioixooxiiioiioxiiiiiioxoioxixxioxxioxixxxxxooooxioxoiiooiixxixooioxixxixixixooxoixoiiooxiioiiixxxxxixiiioxoxoooooxxoiioixiixxxxioioioxxoooiooiooxoiiixxoxiioiiioioxixxoxioixixxxxixxoxoiixioxioxiooiixoioioxiooooioxiioiooxiioiiixxioooxiiooxioioxxxoiixoxooiooiiixxooooxoioiixoxixxxxxxoxoioxoxioxioxixoooxioxiiioixiixooiixxoxxoiioi", "iiiioxo", "xixooiooxoxxxioxixxiixxoiiixoioioxxxiiiixooioixoxoiioxxoiooooxxixxoxoxoxioixiioixoxixiiiixioxooooooiioxiixiixxiiooiiooxxxxioixiixxoixxioxxxx", "io", "oixioiixiiooxooiooioxxixoioioxxioiiioxixoxoooxxoooixoxxixixiiooioiioxxooiixxoioxxiiioxiioooiooiixooxxoxixixioxxxoiixoxxxioxixxioxoxoxoxoixxxxiooioxiiooxoiooxxooixixoixixixiiixioooiiiiixooxiiiioxoxoixxxxixioxioxxxxoixixxiiixxi", "oooioxioxxiooiiiooixiioiiiioiioxioxixioxxoxiixxiiooxxioixoooxix", "xxoixxoxioiiixioooioooixiixioxxoxoxoxxxxiiiiiixiioiioxoooxxxoioxoiixxooooiiioxiiixiooioixioxiixoxoxiixooxioxoxoiixoooioiiooxiixxoxiixxxoxxxiiooxooixoxoiioxxoiooxixixixxixooiiixxxoooxxooooooxioxoxioixiiiiiiixoiiixooiioxixoioxoxixxxoxxixxoiiioxixxiiixxioxooxoixixioioxiox", "oi", "ox", "xoox", "iixixooooxiixixiioxxxxoxxioiiioixixoxxxiioxooxxioiiioxooixooixiooxxxx", "xxxxooxoixiiioiioxooooxioxxxxoixixooo", "ixxxiioi", "xoixxx", "iooiixiixiixixxxoxxxooxxooxoxxioxxo", "xxioxxoxooooxioxxxxoioxoxxiixixxxixiooxxixiixiooiiooiiioooxxxxxoiooioixxooiioioiixxoioxioixoxxioiixxxoxxooxooooixixxxoxioixoxxoxoxixixiooxiioixiooooiiooooiooixxiixoioxoiioxoixixiixxoioioioiixiiioiooxoxxiiioixixooxioixoiooiiixxxixoixxixiioox", "ooxxioixoixxxooooioiioxixiixoxxx", "xoxixoioixiooiioixixooioox", "oxxoixoxxxoxoxxoxooixooioiioo", "ii", "xi", "oooxiooxooiiixiiiiiixoxoixioxioxixixxxxxooxixoxxixoixxxixxxooooxix", "oiioooixxxooixixxoioioxooixxiixooxxoxx", "oixooxxoxioioxxoooooixxiiiooxioxixooxoxioxixiooixxioxoxioiixxoooxoiooiixxiiiooxooxixiiixoioxooiixooioxoxxiiioioioxoixxiioixxoxxiixiioooioxiiooxxiiioxixiooooxxioioixxxooxxoiixoiioiooixooxxxooooooooioiioixxoioixxxiiooxooxxxxioixoxioioxxioiiioixxxioxioxxxoixxooxooxooioxoxoooooioxiixoioioooooxioioioxiixxxioxoxooiiioxixiixooxioooioxxiixoiixxixxiixioooiooooooxoxoooixxxooxioooxxxxxxiiioixxioooooxooiooiiioooxxiixoiixixiioioxoxiioxiixixoxoooxioiixiioixiioiooiooxxoiioiiiixioioxxoiioxoxixoiiooiooio", "ioxiiooixxxoxioooxoiooixioiioixooxiioxioxiooiioioxxiooxxoixxoixixioiooxioioxooxooiioiioxoixxxooixiioixioixooixxoioxoiixooioixxiioxxoioxoxiioiiioxixiooixioiixoxxooiixoiixxiiioiooiixoiooioxxxxooioxoixiixiixoxoxxoxxxioiixiiioixioxxxxxoxoxiioiooxxxoxixoixxxixixoio", "oixi", "oi", "ooxx", "i", "oxoiixooxx", "xoioooioo", "ox", "ioixoixiixxxioixiooixxxxoxxxoiioxxiioxxxxixioixooxxiioxooixoooooxxxixixxxioxxoxiioiioioxxiooiiiioixiooxiooiooxooxxoooixxxxiioiixoxoooixxiixiioiiixoxxxxioiiiixoxioxxioioxxxi", "oooxo", "oiooiioxoxxoiooioooiioxxxooioiixxixixiixxoixxxooxixxoixoioxxoxoiixoxxoxixoxioxiooxiioiixooioioiooiixxxioxxiooxxoiioxioooxoiooxoiixooxiooixxxxooiioixoxiioooiiixxxoiixooixoiiioiixiiiiooxoooxoixxixxoiiooxxixiixoiooioooooiiiioixoixioxxixioxxiiixixxxxioxoxoiiioxixiooioxxixoxxxoxxxxxoixxoxioxoxxooxixoxxixoxoooooxooxioixxxooooxiixxxoixioxiixioxooixxxoxxoiixiioxiiixioxooooiooxoxixxooiooxoxoxxoooxxixoixooooxioxoxxxoxxixoxiixxxxox", "i", "oooi", "xxxxixixxxxoixioioxoiioiioixxixxioiixoxoooiiooooiioxiooxixooooooxxxioxixoiixiiooixoxxxoxiooxiooxoixxiioiiooioixxxxixxxoiiiioooiiioxooxxioiiiooixoioixoxiixixxiioxixioooxiiioooxoioxxxiixiixiiiixxxiioxoooxiooxxxoioxiioooxixoiiooixioiixiioxxoixx", "xooiiixxioo", "oxiooo", "iooxooioiiooioixoxoxxooxoxioxxxoiooxoioxioxooioooixxxixixoiixxixixxoixxoxioxooiixooxxixxoiooxxoxxixxiioxioxoxiiixixiixoxxxxioiiioooxooiiixxoixiiiixoxiixoxoiiiixooxixoxoiixixixooxioiooiioxoxxoxoxoiioxoxxioxooooxoxixxixoxiiixoixxxo", "ioxoiiooixxoooioioxoioxooooxiixoiooixixoixxxiixooxixxixxixoxxxxiiixixxxioioxoixxioixixioxixoxxooxoxoxooxxoxixxoxxoioiixooixxoixixoxxooixxoiixxixxooxooixxiixiiiiioiooioixoooxoxxoxixoiixoxiiiiioooiooxxxixoooixxoixooxiiooxxxxioixxxoooiixoixxxixiiiiiio", "i", "ix", "oxxxiixooioooixxxiiooooixoxoixooiiioiioxxxxxixxxoxxxixoiixxxxooixxioxooixiioiixioioioiooxxxxioxxxiooxiixxoox", "ooxxoxiioxxxioxoxxxixxixoxxioiiiiox", "ooixoxxixxxoxoixxooiixoooxxxixiiiooioooiooixiixixxioiooiooiixoiiixioiiooiiiooioioioxoioiioooiioixooxooiixiixxxixoioxoxoiixoiioooiiioiixxoxixoioioxiixoiooixxxioiixoiiiiixioixooxiixioiioooxoooxxoixixoiiioiixoiixixxxxxoxoxoxxooxoxxoiiiixxiixoiixooiiioooioxioxxxoiixxixoiooxxixixoooxoxxxixooioxixoixxxoxxxoxixooiiixiiiioooxioxxxoioxiixxxiioooxxxiiixxoxxoiixoiixxooxoioxi", "oxioiiiooiioxoiooiiioxixxxxoiioxooxxxxxoxooxioiixixoioioxx", "xxiiooxiiioxxxoxxxoiixi", "oox", "xoiiiix", "oixxiooxoixooiixxiixxxoiixoxoxoooixoxxxxixoxixxixxioiioixioxxxixoioixioooxoxoiooiooioiiiiixiooixxxoxiioxxoioxio", "ixxo", "i", "xxiixoxxiixixxoixiooooxoooooxxooxoxioooxoxxixxixioixixooixixxxioxxxxxoxooioioxxooixixxoxxxiioooioxixiixiiooioxoxixoiioooioxoiioixxioxixixoxoioixxoiiixiioixoiixooioixxiiiiixoxixxioixoxxiiiooiiixxiioioooxxoioooxixoixxxiiooio", "xixooiixi", "ioixxxoxiixooxiioxxiixoxxoxoxxxixiiooixixoixixxiixoiixoxoxxixxioooxoiooioxixxoiooxiiixiiioiixxoixiiixxiiixooxoixoxxiooooixoxxxoxiixxxixioooixioiixxoxixiooxoiioiixxixoxiooxxiiooxxxoxoxoioxxxooxoxoxoiooixiiiioiioixxixixixxooxoixxiiooooiiixii", "oiixxxoxxixoxoooioxxoioi", "oiio", "xixxoixoxiixoxiioixoixxiooioxiixixixx", "oxoxi", "ioxxxx", "iixioooooxxxooiixoxxixoxxxiioioixiiioxoixoxoxxioioxxxoixxixxxioxoiiiixxiixixxoxoxoiioxxixixxioiooooixxioioxxxxxoxiiioxiiioxxiioixioiiooxoxioxxxiixooxoxooioxxxoiooioiiiiiooxoooxoiioiixoxoxxiioiioooxiiiiixxxiiiooixxooioxxxx", "oooxoooxiixioxx", "ioxioooixiioooiiixoxooiooxioxiioooxxoxixioioooooxoiooxxioioxoiixxoioxxixiioixixxxoixixoxixixxixxixooioiioxxoxiixixiooxiiixxioi", "ixoixoiooooxxooxixoixooiiiooxoxoxxixxxxxoxiixooxooiixxxixxoxixoxxoioiiioxxxxiooioioooiioxxxxoxoiooixoioixoiixxxiiixxxxoiiiixiioooxxiixxooixxxxoixoixxoxixoxoiioxiixxxi", "xo", "iooioxxoxxxioxixoooiiioxxiioxxooxoiioiooiioxoxioxoxoixxxoioiiixxxixiiiixiooxoxixxxioxixooxiioxioxxoiiixioioxixi", "xooxoxooiooio", "ixxoxoxoxoooooxixiooioixoixoxiiooxxoiixxioioxxiioxoooiixoxxxooxiooxoxxxxoxiixoxixixoxoxoxixiixixxiixioioxioooxixoioiixioxooxoxxoxoxiioooixoxxooiiixixooxoioxxxoxoxoixiooxixxxoixoxxxoixxioxoioioxxxxoiixixxoixoxxiixxxxiioixoxxxiiiioooxoxixoixooxiixiioxxxxoiiooioixxii", "oxoxiiooioixooxxxoixiixoooxxoxxxxoioxoxxxioxxoiooixioxxixoxxxixiooioxoooiiixxooooioxxxoiixioxixxxooioxiioiixxxoxoxioiioooixxiiiooxooixoxoixiiiixiooiiixoixxoixxooiiooooiiixixoixoixioxioioxioxixoxooiooiixiiiiiiixixxoxxoooxoioixxixxioioxxxixiixxxooxiioxoixxxiiixooiixoiiixoxxxxixxiooiiiooxixxoiooxiooxxiiooooiixxxxiioxix", "iiooiooxooxioxxoioioxixxioxxiooxiioiixixioxoixxoxoxxxiiooiiiixoooxxxxiixoioioixxoioiioiioioxoioiooxooioxxxoooioooxoxooxixoixiooxooxxxxxioxxxxoooxoioxxxiioxiiooxxxxiixixixoxioooxoxxooixoxioiioxoioxoixiioxooxxxoiixoixixixxoxiiioixoixxooxiooxxoiiiooooxiixixiixxxiiooiooxoixixoixooxioixioxixoxixoioiioiiixxxooxxxxoiixoiixooiioixioxxoxxxixixxioxiiiixoxoxiixoooioiixioxoioixioxoixxooixixoioiiioiixxiixoooooooxxoxxoxxixiiixxxixoxoixxiioxoiooiixxxooxxoxoixxxoxioiixioo", "ixoxixxo", "oixxxxixooxoixoixioxooxoiixoiooioixioxoiooooxixooxxiiiiiooixxxoixoixxixxiooioxiioxxoixxixxoioiiooioxooooixxoiiixiooiixoxoxioiiooxxixoxiioixoixxioooiixiiixxoioooxioixxioixxoxxiioioiioxxioxioiooiiiiioxoiiioixxxiiooiiooixxooixoxiiooiooiixxiixioiiiixiooxoioiixxxioo", "iio", "oioxoxxxxiiiiiixxoixxxiixoxoiooooiooxoxoioixxooxiiixoxooxoixoixixixioiiioxixiixxixxoioixoxixioixixoxioxioioixixoiiiiiixixoxoixixxioooiixooxxoixoixxioioxxoxxioixiooioxioioioioiiooxiixxxoxioxxoioxoooixiioxixio", "ioiiiiixoixoooixooooixoooxoiooxxxxixxooxxixixiiioxxioioiooiixoiooooooixxxxoxxooxoioixixoxioxixooixooioxioxiooooxxxixioxiooxioixooxioiiixxooixxxxxxooxoooiiiiooiiiixxixixoixoxioxoixioxxiixixo", "xiox", "ioixiixxooxiiixooxiioxxoiixoiooxoooioxooixoxo", "iiooxxxoxxixxxooixioioooxxixoxioxiiioxooiiiioiooiiooxoi", "ioxxxooxxxxiiiiixixixioiixoxooxixxioixiixxiioxxixxoioiixioiioooiiixoioxiooiiiioioxixixoxxooioixioxioioiioiooixoioooiioxxxixoxiixiooxoxixiooiiioxoixxixiiooioxooixooiiioiixiiioooiioxioiiooxiioioooxioxxioixioxoooxooixioiiixooixioxoxixioxoioiiioixioxoioooxioiioixiixioiiixxxxioiiixxiiioixxxiooxooxioxxoxoooxooixxixooixixiiiioiiooixxoxoioxiooioixoxooxooxooixooiixxixixxoioixoioxiiixooxxoxoioixioixiixxiixoixoooxxixxxxoixioo", "xiioxoxoiooioooxxioooixiixiooxoixxiiooixxixoiioixoxoxooxxoxiiixixiooiixoooiixooxioxixoxxoiiixooxixxxixiiioxxxiooxxoxioooxxixooiooiioxixoxxxoixxixxixixioxioxixxxoxooxxixoixooooiooxxoxixxixxxixooxoooxxoixxo", "ox", "oixxiixixxixioooooioixoxxoxoiiixxooxxoioxoooooxoxxiioioxoiiixiixiiioiiiiiioxiiixiiooiioooxioiiiooixxoixoxxoioixxiiixixxioiiioooioio", "xxoixiioo", "xiooxxixooxxxioxixxoxoooioiixooiixxxiixixxxiixooiixixioixiiiioiixooxiiiiiixxixooooxoooixiiixxixoooxoxixioxixixoiiiiixioiiiixxoiioixxxoixiioxixoxxxixxxiiiixxixxxxoxiooixoxxxoxooxoxooixxooioiiooixioxooxxxoooixoxiixixooxixoioxxxooxoixioiioxxiooxxxxixioooxiooixxxixooiioxoooxiioiixooioixoxiooxixoixxxxxxooixoxox", "oxioiioixooioxxoixxi", "xixxxiiiiixiixxiioiixooooiixxiixooiioxiiixxoooxxxoxioixxiixxxxoooixixixiioiiooioxoxooioxxoiooxooiixx", "ixiioixixiixooxoixixixiixoiooxiiooixxoooixxoxioioixiiiiixoixixxxxxxxioxooxxixoioxixxiiixoxiixooxoixoiiixoixooooixxoioixxixxixoooxoxoxxoooooxoooxoiiiooxixooiiiiioxxoioiixioxoxxioxoxoxoixxixixoxxxoxiixiooxoixixoiixxioxxixxxxoixixixioixxixiiioxooxxxixxoxiiixxoiixoxoioioxxiioixooiixoxioxoxxoiioxooioxoioxixixoxxixoiioiiioxooixiioixxoiioxxioxooiixixxooooxxixxoioioiiiiixxoioioixxioxxxxxoxiooooioxoxiioioxiixiioxxiiiooiiiooxixoxixooooioixiiiixixooxoxxixixixoxixiiixioxoiiixooixixox", "xxxoxoiixixxoixioiiiooxxooooxxixxxxoiixiixxiixooiioiiixoooxoiooiiixioxoxixxxioxiiioixxiooxiiixioixooooixixoioxxxxxoioxiioxxixooxxxxoxxxiooxooooxxixxxioxixxioxoxxiooxioxiooixxoiooxiixxxixixoioixooxxiiixxoioxoxioxxxiooioxixoxiiooxxxxoioiiiiioxoxixioiiiiioxoiixiooooioixiiioxxoioiiioxiiioxioooxioxooixiiiiiooixoxiiixxoxoixooixxioxxioooioiixixiooxiixixxoooooixxoioixixxxiioixxoxixixioooioxixioooioooxiixiooooxooxxoxxoxixoixiioiioioxxxxixooxxo", "xiiixxixiioooxxixioixoxooxoiooioioioiixooxoxoiioiioixxixxxoooxioioxoiooioiioxixxoxxxxooixiiixxxoioxoxoooxioiioxxixxoooxoixixoxxxoixixxxiiiiioxoixoxiixooxoiiooxxxoxxiooixxxoxioiooiioxxooioooxxoxooioxoxxoxioxoxoiixxxooiixiioiixoixoxiixoxixooooooiiioiixxoioxoxiiioixxooxooioxiioooxiiiiiioiiixoioxixxxioixxooxxoiooxxxxoioiiooooxiixxxioxxxxioiixiixxxxiioiiixxxiioxioooooooioxoiioxooooxoiiiioooxoxioiixooioooooioxoixxoooooiixxixooixxxioiixixixxxoxoxxixiixxxxoixoiooxxiioioxixixixoxioiooixxioiooixxiixoooioii", "ixoooi", "ioxoxoioooiixxoioxoixiiiiooxxiioxxxoixxioxi", "xiioooooioox", "oo", "o", "xooioixx", "oixxioooioixooxoixxixixooiiooxooioxixxioxiiixoixixxxoioxxxooxxxooxoiixxxooxioiooxxioxoioioooxoiooxxioixxxxooixiixixoiiioixoooixxxxoxxxoioiooixxoxxiixooixoiioioixxxoixxoixxoxxxoooioxoxixooxoiixooixxxixoii", "xioooxxxxoixiooxxixix", "o", "oxiooxxiixixiixixxiiooixixoiiioxooxioxxiiiioiooxixxoxoiiiooixxoixoiioxiiooiooi", "xxxixoxxxxiixoiioooooxxiooixxxiixxiooxxixooxiixooxixxiixixoixixxoio", "xiixxiixoxoooxoixiioiioioioioxiooxxoixixoiooxixxixiioooooixoxoo", "oixoixxoxioxoxxxoxoioixooiiooxxooiooiiioiioixxoiiixixxioxoxxixiiooxoiioxioiioxoxooixxxxxiixxxxxiioxoxo", "iooioxoxoixxxxoioixixoxoixixioxioxoxxxxixoioxxxoooiioiiioixxoxoixoxxiio", "xoxi", "ixooxooooio", "xixoxoxioxoixioixxoxixoxoiioxoxiiiiooxxxooxoxioxxioiiixxoxoxiixxoixioxxoixioixixoxxioxoixoxoooxoxxxioxoooiooioiixixxxixxxxiioiiiooxiooxxixoxooioixxoixxoixoxiooiixooiooixoiixoiioixxioxoioooxoxioiixoxiiioxoiiiixxiiiooioiioixixoooxixxiooioxoxoxxxooooxxiiioioiiixoxioxoioioiiioiiiiooixoixixixoxioxioxiioxioooiiioxxiooxo", "oiixoioixooxxixoxoxooixoxiixoixx", "iooo", "iixxioiooxoioiixxoxxxxoioiioiioooioioiioiooooooixoxooxxiooxxiiooxixxxoiiixiiiixoxoxixxxoiixooioxxxxxooixooiixioixiioxxooxooioooiixooxoiooxoiixxioooooiioixxooiixioioxiooxoiioiooooooooooxxioxoioxxiixoixiooooiooiiiixiiioio", "xooxxioxixoiioixxixxxxxooxixxoiooooxiooxiiixooooiioooxixoxxooxoiooixxxxoxxoiooxxoxoiixooooxoiiooxxoxiooxoixoxixiixoxooxioiiixxixoxxxxooioixoixooioiixoxixooioiiiiooxoooxioxxiooioiixiioixiiioxiiooooxixooixoxioiiiioxxxoxxixxoxiixiooooixxiooioxoxoxiiioiooxxooioiixoxoxooiiooiooxxoxxxoxioxiiixxooixxixxioxoixiooiixxooiixoioxxoxioxioiixoxxxixoixxoixioxoxoxxooxxiiiioioxixiiiixiixixioixiiiioxoiiiiooxxoxxoi", "xxoi", "iiixxixxioxixoooxiioooioioioxoioooxiiooooxixxxixixiooioixixoxxoxooixioixxxoxiixxixoxiii", "iioi", "oixioxxxoooixoooxio", "iooooioxxoxixixixoiioixoiiixxxixoiiiiioxixxioxxoxixoioioiooxxxoixioiixiiiiooixixoixxooxxxoixooiixxxxoxixioxioixooiioxixxioiiixixo", "ooxixioxoxxoxoxiiiioxoixoixxiixioxxixxxxxioixoxxxoioiiio", "oooxxoioxiooxooiiiooxxxooxoixoxioioioixxiooixooxioixiiiooxxoooxxxxixiooooixxxixoooioixoixooiiix", "iiixoxixxoioxxoixxxoixxoxiioixoxioixiixiioixxxoxioooxioioxixioixxoxiooxxixoxixiixiioiixxixoxiioiiixooiiioioxooxoxioooixoxxxxxxxoxooixxixixxioxooxiixxoixioiiooiixixxioioixxoxooxixooxxoixoxiixixioiiioxoxxoxoioixioiiixiiiooxoixxxioxixooxiixioxooioooixixoiiioooiiioioxxoiixoxxoxoxoiooooiooxxooiiiooxoiooiooxxixioxxxxxiiooiiooixxixiooxixiixoxiixxxxxoiixiioxxoxxoiiioooiiioxioxiioiixioioioxoxixxxxxoxxooioooxoiixooxxixoiiiixixoioxxiiixxxx", "xxoxoooiioxxoiixoxoxiixxxixoixooxxiiixxoooxx", "xiiiixxxiooixxxiixxiooxxioxixixxixoixxooiiooooooiixoxoixxi", "oxxioiiixoxxooixxxixioioiiixiiiiixoxxiixxoioxxiixooixoiioxoioooxxxixxxxiooiioxoxxiixiioxiixooiixiioxooooioioxooxoooioiioxxoioxxoiiioxxoooiixoxixixxoixxixoxxixiioioixxiooxioioxiioiioixxxxxixxxooixxxixoooxxioxiixxoooioioiiixooioooooiioioxoxxiioxooxxxioooxoiiiixixooixoooxioxoxoixooxoiiiiixxxxoxoixoiioixixxxx", "oioiooiixioxxoixxoxxxoxxiixoxoioxooiooxxooxxo", "ixix", "iiixiioxxoioiiixxxxoooxoixxoxxxoioxooxxooioxoiixixoooiooxoxxxoiioioixxixxiixoiioxoiixxioxioxooixooioiiiooooiiiioxxxxiioioxixioiixoixioxoioxioxxxoiiioxxxiioxooxoioxxoixoooxioioioioxooioxoxxioxoxoxxixxiooiioxiioooooioixooxiiioxoioiixxxixxiixxoiixixixxixxooooxoxioiioxixiiooxixxxxioooioxooooxxxiixoxoiooixxxooooooixxxoxioooxxxxxxiooooooxoxoxioxxixooxxoioixxiooixoxoxixxxxiioixioixxxoxxxixoxxoxiixxoiiixixixiiioxioixoixixoxooiiiixxxiooioooiooiioxoxioixoiioiixxixoixxxxoxxxiixoixoiooxxoxioiiixxxixxooioxoooxxxooo", "i", "xxioioxoxoixoxixxoiooiixioiooxooxoxooioiixooixoioooxxioioxixxoixixiioxiixoxioxxixxioxxxixooooioxoxoooixxxxoooxoxxioxiixoiioxxxioxooixixoooxooixxxxxiiioixooixxxxioxoxoxxxxxiiioiioxoixoxoxioxioiixiixoxxxoiioixoixixixxixioiiooixoiiioxooixixooioxxiixxoixixooioxixiiiooxxixxiiiixoxxxooioiixxiixxioxixoioiiiiixoxoxxxoxxioxxixoxxxooixxioxoxoooooxiiioxxxooxxooixiixoooiiiioixxoooxioiiioooxioxox" },
                    "oxxoixoxxxoxoxxoxooixooioiioox");
                Assert(t, 1);
                var head = new ListNode(new int[] { 1, 2, 3, 4, 5 });
                var newHead = s.ReverseKGroup(head, 0);
                Console.WriteLine(newHead.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }

        static void Assert<T>(T o1, T o2)
        {
            if (o1 is IList list1)
            {
                var list2 = o2 as IList;
                if (list1.Count == list2.Count)
                {
                    for (int i = 0; i < list1.Count; i++)
                        if (!list1[i].Equals(list2[i]))
                            throw new Exception(i + ": " + list1[i] + " " + list2[i]);
                }
            }
            else
            {
                if (o1.Equals(o2))
                    return;
                throw new Exception(o1 + " " + o2);
            }
        }
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }


    public class Solution
    {
        struct hp
        {
            public hp(int minVal, int maxCurVal)
            {
                this.minVal = minVal;
                this.maxCurVal = maxCurVal;
            }
            public override string ToString()
            {
                return minVal + "," + maxCurVal;
            }
            public int minVal;
            public int maxCurVal;
        }
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int m = dungeon.Length, n = dungeon[0].Length;
            var dp = new int[m + 1, n + 1];
            for (int i = 0; i < m; i++)
                dp[i, n] = int.MaxValue;
            for (int j = 0; j < n; j++)
                dp[m, j] = int.MaxValue;
            dp[m, n - 1] = dp[m - 1, n] = 1;
            for (int i = m - 1; i >= 0; --i)
                for (int j = n - 1; j >= 0; --j)
                {
                    int min = Math.Min(dp[i + 1, j], dp[i, j + 1]);
                    dp[i, j] = Math.Max(min - dungeon[i][j], 1);
                }
            return dp[0, 0];
        }

        private void dfs(int[][] map, int curHp, int lowestHp, int kx, int ky)
        {
            //curHp += map[kx][ky];
            //if (curHp < lowestHp)
            //    lowestHp = curHp;
            //if (-curHp > hp)
            //    return;
            //if (kx == px && ky == py)
            //    hp = -lowestHp;
            //if (kx < px)
            //    dfs(map, curHp, lowestHp, kx + 1, ky);
            //if (ky < py)
            //    dfs(map, curHp, lowestHp, kx, ky + 1);
        }

        public IList<int> CountSmaller(int[] nums)
        {
            if (nums.Length == 0)
                return new int[0];

            var cnts = new int[nums.Length];
            var sortArr = new List<int>();
            sortArr.Add(nums[nums.Length - 1]);
            for (int i = cnts.Length - 2; i >= 0; i--)
            {
                var index = FindIndex(sortArr, nums[i]);
                cnts[i] = index;
                sortArr.Insert(index, nums[i]);
            }
            return cnts;
        }

        private int FindIndex(List<int> arr, int value)
        {
            var lo = 0;
            var hi = arr.Count - 1;
            while (lo < hi)
            {
                var mid = (lo + hi) >> 1;
                if (arr[mid] < value)
                    lo = mid + 1;
                else
                    hi = mid;
            }
            if (arr[lo] < value) return lo + 1;
            return lo;
        }

        public int Respace(string[] dictionary, string sentence)
        {
            var dp = new int[sentence.Length + 1];
            var sb = new StringBuilder();
            for (int i = 1; i <= sentence.Length; i++)
            {
                sb.Append(sentence[i - 1]);
                var vals = dictionary.Where(str => EndWiths(sb, str)).Select(str => dp[i - str.Length]);
                dp[i] = dp[i - 1] + 1;
                if (vals.Any())
                    dp[i] = Math.Min(dp[i], vals.Min());
            }

            return dp[sentence.Length];
        }

        private bool EndWiths(StringBuilder sb, string d)
        {
            var diff = sb.Length - d.Length;
            if (diff < 0)
                return false;
            for (int i = 0; i < d.Length; i++)
                if (d[i] != sb[diff + i])
                    return false;
            return true;
        }

        public bool HasPathSum(TreeNode root, int sum)
        {
            return dfs(root, sum, 0);
        }

        private bool dfs(TreeNode node, int sum, int currVal)
        {
            if (node == null)
                return false;

            currVal += node.val;
            if (node.left == null && node.right == null && currVal == sum)
                return true;
            if (dfs(node.left, sum, currVal))
                return true;

            return dfs(node.right, sum, currVal);
        }

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            if (m < 1)
                return 0;
            int n = obstacleGrid[0].Length;
            if (n < 1)
                return 0;

            var dp = new int[m];
            dp[0] = 1;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (obstacleGrid[i][j] == 1)
                        dp[j] = 0;
                    else if (j > 0)
                        dp[j] += dp[j - 1];
            return dp[n - 1];
        }

        public int KthSmallest(int[][] matrix, int k)
        {
            var arr = new int[matrix.Length * matrix[0].Length];
            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[0].Length; j++)
                    arr[index++] = matrix[i][j];
            Array.Sort(arr);
            return arr[k - 1];
        }
        public int FindLength(int[] A, int[] B)
        {
            int max = 0;
            var map = new int[B.Length + 1];
            for (int i = A.Length - 1; i >= 0; i--)
                for (int j = 0; j < B.Length; j++)
                {
                    if (A[i] == B[j])
                    {
                        map[j] = 1 + map[j + 1];
                        if (max < map[j])
                            max = map[j];
                    }
                    else
                        map[j] = 0;
                }
            return max;
        }

        Random random = new Random((int)DateTime.Now.Ticks);
        public int FindKthLargest(int[] nums, int k)
        {
            return PartQuickSort(nums, 0, nums.Length, k - 1);
        }

        private int PartQuickSort(int[] nums, int si, int len, int k)
        {
            if (si == k && len == 1)
                return nums[si];
            var bi = random.Next(si, si + len);
            var bv = nums[bi];
            int i = si, j = si + len - 1;
            while (i <= j)
            {
                while (bi <= j && nums[j] <= bv) j--;
                if (bi <= j)
                {
                    nums[bi] = nums[j];
                    bi = j;
                }
                while (i <= bi && nums[i] >= bv) i++;
                if (i <= bi)
                {
                    nums[bi] = nums[i];
                    bi = i;
                }
            }
            if (bi == k)
                return bv;
            nums[bi] = bv;

            if (bi > k)
                return PartQuickSort(nums, si, bi - si, k);
            else
                return PartQuickSort(nums, bi + 1, len - bi + si - 1, k);
        }

        private void QuickSort(int[] nums, int si, int len)
        {
            if (len < 2)
                return;
            var bi = random.Next(si, si + len);
            var bv = nums[bi];
            int i = si, j = si + len - 1;
            while (i <= j)
            {
                while (bi <= j && nums[j] <= bv) j--;
                if (bi <= j)
                {
                    nums[bi] = nums[j];
                    bi = j;
                }
                while (i <= bi && nums[i] >= bv) i++;
                if (i <= bi)
                {
                    nums[bi] = nums[i];
                    bi = i;
                }
            }
            nums[bi] = bv;

            QuickSort(nums, si, bi - si);
            QuickSort(nums, bi + 1, len - bi + si - 1);
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var kStart = head;
            var prev = head;
            var curr = head.next;
            var next = curr?.next;

            int cnt = 2;
            while (curr != null)
            {
                curr.next = prev;
                prev = curr;
                curr = next;
                next = next?.next;
                if (cnt%k==0)
                {
                    kStart.next = null;
                }
            }
            return prev;
        }

        public ListNode ReverseKGroup2(ListNode head, int k)
        {
            var kStart = head;
            var prev = head;
            var curr = head.next;
            var next = curr?.next;

            head.next = null;
            while (curr != null)
            {
                curr.next = prev;
                prev = curr;
                curr = next;
                next = next?.next;
            }
            return prev;
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public override string ToString()
        {
            var vals = new List<int>() { val };
            var curr = next;
            while (curr != null)
            {
                vals.Add(curr.val);
                curr = curr.next;
            }

            return string.Join(", ", vals);
        }

        public ListNode(int[] arr)
        {
            if (arr == null || arr.Length < 1)
                throw new ArgumentException(nameof(arr));

            val = arr[0];
            if (arr.Length > 1)
                next = new ListNode(arr.Skip(1).ToArray());
        }
    }


    class A
    {
        public void test(int i)
        {
            Console.WriteLine(i);
            lock (this)
            {
                if (i > 10)
                {
                    i--;
                    test(i);
                }
            }
        }
        public string Val { get; set; }
        public override bool Equals(object obj)
        {
            Console.WriteLine("equ");
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            Console.WriteLine("hash");
            return base.GetHashCode();
        }
    }
}
