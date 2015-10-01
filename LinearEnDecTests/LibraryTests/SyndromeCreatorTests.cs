using NUnit.Framework;
using System;
using LinearEnDecTests;
using LinearEncoderDecoderLibrary;
using System.Collections.Generic;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class SyndromeCreatorTests
	{
		[Test ()]
		public void TestCreateErrorVectors ()
		{
			int n = 6;
			SyndromeCreator sc = new SyndromeCreator ();
			int[,] errorVectors = sc.CreateErrorVectors (n);

			for (int i = 0; i < n + 1; i++) {
				for (int j = 0; j < n; j++) {
					Console.Write(errorVectors[i,j]+" ");
					if (j == n - 1)
						Console.Write ("\n");
				}
			}
		}

		[Test ()]
		public void TestCreateSyndrome()
		{
			int[,] HMatrix = new int[,] {
				{1,1,1,1,1,0,0,0 },
				{0,1,0,1,0,1,0,0 },
				{1,0,1,0,0,0,1,0 },
				{1,0,0,0,0,0,0,1 }
			};
			SyndromeCreator sc = new SyndromeCreator ();
			Dictionary<int[], int[]> errorVectorAndSyndromeArray = sc.CreateSyndrome (HMatrix);
			int[][] errorSyndromes = new int[HMatrix.GetLength(1)][];
			int[][] errorVectors = new int[HMatrix.GetLength(1)][];
			errorVectorAndSyndromeArray.Keys.CopyTo (errorSyndromes, 0);
			errorVectorAndSyndromeArray.Values.CopyTo (errorVectors,0);

			Console.WriteLine ("These are the error syndromes:");
			for (int i = 0; i < HMatrix.GetLength(1); i++) {
				for (int j = 0; j < HMatrix.GetLength(0); j++) {
					Console.Write(errorSyndromes[i][j]);
				}
				Console.Write ("\n");
			}

			Console.WriteLine ("These are the corresponding error vectors:");
			for (int i = 0; i < HMatrix.GetLength(1); i++) {
				for (int j = 0; j < HMatrix.GetLength(1); j++) {
					Console.Write(errorVectors[i][j]);
				}
				Console.Write ("\n");
			}
		}

		/*
		 *Tests the CreateSyndrome2() from SyndromeCreator which is currently commented out.
		 *
		[Test ()]
		public void TestCreateSyndrome2()
		{
			
			int[,] HMatrix = new int[,] {
				{1,1,1,0,1,0,0 },
				{1,1,0,1,0,1,0 },
				{1,0,1,1,0,0,1 }
			};
			SyndromeCreator sc = new SyndromeCreator ();

			int[] syndromes = sc.CreateSyndrome2 (7, HMatrix);


				for (int j = 0; j < HMatrix.GetLength (0); j++) {
					Console.Write (syndromes [j] );
				}
				Console.Write ("\n");

		}
		*/
	}
}