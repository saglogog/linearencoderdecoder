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
		/** Make CreateDecimalFromBinary() to use 
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
		*/

		/*
		 * Make CreateBinaryFromDecimal() to use 
		[Test ()]
		public void TestCreateBinaryFromDecimal(){
			int decimalNumber = 875;
			int[] expectedBinary = new int[]{ 1, 1, 0, 1, 1, 0, 1, 0, 1, 1 };

			HelperClass hc = new HelperClass ();

			Console.WriteLine ((int)Math.Floor (Math.Log (decimalNumber, 2)) + 1);

			int[] actualBinary = hc.CreateBinaryFromDecimal (decimalNumber);

			for (int i = 0; i < 10 ; i++) {
				Console.Write (actualBinary [i]+" ");
			
			}
		}
		*/

		[Test ()]
		public void TestSubtractBinaries(){
			int[] binary1 = new int[]{ 1, 0, 0, 1, 1, 1, 0 };
			int[] binary2 = new int[]{ 1, 1, 0, 1 };
			int[] expectedResult = new int[]{ 1, 0, 0, 0, 0, 0, 1 };
			HelperClass hc = new HelperClass ();

			int[] actualResult = hc.SubtractBinaries (binary1, binary2);

			for (int i = 0; i < 7; i++) {
				Assert.AreEqual (expectedResult [i], actualResult [i]);
				Console.Write (actualResult [i]);
			}
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

		[Test()]
		public void TestConvertCharArrayTo2DIntArray(){
			HelperClass hc = new HelperClass ();
			int[,] twoDimArrayExpected = new int[,]{ 
				{ 0, 1, 0, 1, 1 },
				{ 1, 1, 1, 1, 1 },
				{ 0, 1, 1, 1, 0 },
				{ 0, 1, 0, 1, 0 } };
			char[] charArray = new char[] {'0','1','0','1','1','\n','1','1','1','1','1','\n','0','1','1','1','0','\n','0','1','0','1','0','\n'};
			int[,] twoDimArrayActual = hc.ConvertCharArrayTo2DIntArray (charArray, '\n');
			for (int i = 0; i < twoDimArrayExpected.GetLength (0); i++) {
				for (int j = 0; j < twoDimArrayExpected.GetLength (1); j++) {
					Console.Write (twoDimArrayActual [i,j]);
					Assert.AreEqual(twoDimArrayExpected[i,j],twoDimArrayActual[i,j]);
					if (j == twoDimArrayExpected.GetLength (1) - 1) {
						Console.Write ("\n");
					}
				}
			}
		}

		[Test()]
		public void TestConvert2DIntArrayToString(){
			int[,] twoDimArrayExpected = new int[,]{ 
				{ 0, 1, 0, 1, 1 },
				{ 1, 1, 1, 1, 1 },
				{ 0, 1, 1, 1, 0 },
				{ 0, 1, 0, 1, 0 } };
			MockSetupClass msc = new MockSetupClass ();
			msc.FillMatrix ();
			HelperClass hc = new HelperClass ();

			Console.WriteLine (hc.Convert2DIntArrayToString(twoDimArrayExpected,'\n'));
		}
	}
}