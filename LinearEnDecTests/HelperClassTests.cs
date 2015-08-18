using System;
using NUnit.Framework;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class HelperClassTests
	{
		[Test ()]
		public void TestConvertRectangulartoJaggedLtoA (){
			int[][] jagged;
			if (PropertyClass.PArray == null) {
				MockSetupClass msc = new MockSetupClass ();
				msc.FillMatrix ();
			}
			int[,] rectangular = PropertyClass.PArray;
				
			HelperClass hc = new HelperClass ();
			jagged = hc.ConvertRectangulartoJaggedLtoA (rectangular);

			for (int i = 0; i < jagged.GetLength (0); i++) {
				for (int j = 0; j < rectangular.GetLength (1); j++) {
					Console.Write (jagged [i] [j]);
					if (j == rectangular.GetLength (1) - 1) {
						Console.Write ("\n");
					}
				}
			}
		}

		[Test ()]
		public void TestConvertRectangulartoJaggedCtoA (){
			int[][] jagged;
			if (PropertyClass.PArray == null) {
				MockSetupClass msc = new MockSetupClass ();
				msc.FillMatrix ();
			}
			int[,] rectangular = PropertyClass.PArray;

			HelperClass hc = new HelperClass ();
			jagged = hc.ConvertRectangulartoJaggedCtoA (rectangular);

			for (int i = 0; i < jagged.GetLength (0); i++) {
				for (int j = 0; j < rectangular.GetLength (0); j++) {
					Console.Write (jagged [i] [j]);
					if (j == rectangular.GetLength (0) - 1) {
						Console.Write ("\n");
					}
				}
			}
		}

		/*
		 * Make MultiplyBinaries public to use.
		[Test ()]
		public void TestMultiplyBinaries(){
			HelperClass hc = new HelperClass ();
			Assert.AreEqual(0, hc.MultiplyBinaries (0, 1));
			Assert.AreEqual(0, hc.MultiplyBinaries(1,0));
			Assert.AreEqual(0, hc.MultiplyBinaries(0,0));
			Assert.AreEqual(1, hc.MultiplyBinaries(1,1));
		}
		*/

		/*
		 * Make MultiplyBinaries public to use.
		[Test ()]
		public void TestAddBinaries(){
			HelperClass hc = new HelperClass ();
			Assert.AreEqual(1, hc.AddBinaries (0, 1));
			Assert.AreEqual(1, hc.AddBinaries(1,0));
			Assert.AreEqual(0, hc.AddBinaries(0,0));
			Assert.AreEqual(0, hc.AddBinaries(1,1));
		}
		*/

		[Test ()]
		public void TestMultiply2DArrayByVector(){
			int[] expectedArray = new int[]{ 1, 0, 1 };
			HelperClass hc = new HelperClass ();
			int[,] TwoDMatrix = new int[,] {
				{1,1,1,0,1,0,0 },
				{1,1,0,1,0,1,0 },
				{1,0,1,1,0,0,1 }
			};

			int[] vector = new int[]{ 1, 1, 1, 1, 0, 1, 0 };

			Assert.AreEqual( expectedArray, hc.Multiply2DArrayByVector (TwoDMatrix, vector));
		}

		[Test ()]
		public void TestCreateDecimalFromBinary(){
			//Arrange
			int[] binaryNumber = new int[]{ 0,1,1,0,1,0,1};
			int expectedDecimal = 53;
			HelperClass hc = new HelperClass ();
			//Act
			int actualDecimal = hc.CreateDecimalFromBinary (binaryNumber);
			//Assert
			Assert.AreEqual (expectedDecimal, actualDecimal);
		}

		[Test ()]
		public void TestLogarithms(){
			Console.WriteLine (Math.Log (53, 2));
		}
		/*Another test for the ConvertRectangulartoJaggedCtoA method
		[Test ()]
		public void TestConvertRectangulartoJaggedCtoA2 (){
			int[][] jagged;

			if (PropertyClass.PArray == null) {
				MockSetupClass msc = new MockSetupClass ();
				msc.FillMatrix ();
			}
			int[,] rectangular = new int[,] {
				{ 1, 1, 1, 0, 1, 0, 0 },
				{ 1, 1, 0, 1, 0, 1, 0 },
				{ 1, 0, 1, 1, 0, 0, 1 }
			};

			HelperClass hc = new HelperClass ();
			jagged = hc.ConvertRectangulartoJaggedCtoA (rectangular);

			for (int i = 0; i < jagged.GetLength (0); i++) {
				for (int j = 0; j < rectangular.GetLength (0); j++) {
					Console.Write (jagged [i] [j]);
					if (j == rectangular.GetLength (0) - 1) {
						Console.Write ("\n");
					}
				}
			}
		}
		*/
	}
}