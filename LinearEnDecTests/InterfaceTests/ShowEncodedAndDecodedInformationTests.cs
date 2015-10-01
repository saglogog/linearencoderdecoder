using System;
using NUnit.Framework;
using LinearEncoderDecoderLibrary;
using LinearEncoderDecoderInterface;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class ShowEncodedAndDecodedInformationTests
	{
		[Test ()]
		public void TestGetIntArrayFromString(){
			//Arrange
			Random rd = new Random();
			int[] intArrayExpected = new int[rd.Next(20)];
			for (int i = 0; i < intArrayExpected.Length; i++) {
				intArrayExpected [i] = rd.Next () % 2;
			}
			//Act
			HelperClass hc = new HelperClass();
			string data = hc.ConvertIntArrayToString (intArrayExpected);
			ShowEncodedAndDecodedInformation se = new ShowEncodedAndDecodedInformation ();
			int[] intArrayActual = se.GetIntArrayFromString (data);

			//Assert
			for (int i = 0; i < intArrayExpected.Length; i++) {
				Assert.AreEqual (intArrayExpected [i], intArrayActual [i]);
			}
		}

		[Test ()]
		public void TestGenerateEncodedInfo(){
			//Arrange
			MockSetupClass msc = new MockSetupClass();
			if (PropertyClass.PArray == null) {
				msc.FillMatrix ();
			}
			Random rd = new Random();
			int[] intArrayExpected = new int[PropertyClass.PArray.GetLength(0)];
			for (int i = 0; i < intArrayExpected.Length; i++) {
				intArrayExpected [i] = rd.Next () % 2;
			}
			HelperClass hc = new HelperClass();
			string data = hc.ConvertIntArrayToString (intArrayExpected);
			//Act
			ShowEncodedAndDecodedInformation se = new ShowEncodedAndDecodedInformation ();
			int[] encodedInfo = se.GenerateEncodedInfo (data);
			string encodedData = hc.ConvertIntArrayToString (encodedInfo);
			string pString = hc.Convert2DIntArrayToString (PropertyClass.PArray, '\n');
			//Assert
			Console.WriteLine("Data:\n" + data + '\n');
			Console.Write ("Encoded data: \n" + encodedData + '\n');
			Console.Write ("PArray:" + '\n' + pString);
		}

		[Test ()]
		public void TestGenerateDecodedInfo(){
			MockSetupClass msc = new MockSetupClass ();
			if (PropertyClass.PArray == null) {
				msc.FillMatrix ();
			}
			Random rd = new Random();
			int[] intArrayExpected = new int[PropertyClass.PArray.GetLength(0)+PropertyClass.PArray.GetLength(1)];
			for (int i = 0; i < intArrayExpected.Length; i++) {
				intArrayExpected [i] = rd.Next () % 2;
			}
			//string data = hc.ConvertIntArrayToString (intArrayExpected);
			MatrixCreator mc = new MatrixCreator();

			string codeword = "";
			for (int i = 0; i < PropertyClass.PArray.GetLength (0) + PropertyClass.PArray.GetLength (1); i++) {
				codeword += (rd.Next ()%2);
			}

			ShowEncodedAndDecodedInformation se = new ShowEncodedAndDecodedInformation ();

			/* --writes error vectors in output if the tested method is set to return error vectors
			int[][] errorVectors = se.GeneratedDecodedInfo (codeword, mc.HCreator ());
			Console.WriteLine ("Error Vectors:");
			for (int i = 0; i < PropertyClass.PArray.GetLength (0) + PropertyClass.PArray.GetLength (1); i++) {
				for(int j = 0; j<PropertyClass.PArray.GetLength (0) + PropertyClass.PArray.GetLength (1);j++){
					Console.Write (errorVectors [i][j]);
				}
				Console.WriteLine ("");
			}
			*/

			/* --writes error syndromes in output if the tested method is set to return error syndromes
			int[][] errorSyndromes = se.GeneratedDecodedInfo (codeword, mc.HCreator ());
			Console.WriteLine ("Error Syndromes:");
			for (int i = 0; i < PropertyClass.PArray.GetLength(1)+PropertyClass.PArray.GetLength(0); i++) {
				for (int j = 0; j < PropertyClass.PArray.GetLength (1); j++) {
					Console.Write (errorSyndromes [i][j]);
				}
				Console.WriteLine ("");
			}
			*/

			/* --writes out the HMatrix passed to the tested method if the method is set to return the HMatrix
			int[,] HMatrix = se.GeneratedDecodedInfo(codeword, mc.HCreator());
			Console.WriteLine ("H matrix:");
			for (int i = 0; i < HMatrix.GetLength (0); i++) {
				for (int j = 0; j < HMatrix.GetLength (1); j++) {
					Console.Write (HMatrix [i, j]);
				}
				Console.WriteLine ("");
			}
			*/

			Console.WriteLine ("Incorrect codeword:");
			for (int i = 0; i < PropertyClass.PArray.GetLength (1) + PropertyClass.PArray.GetLength (0); i++) {
				Console.Write (codeword [i]);
			}
			Console.WriteLine ("");

//			 -- writes out the correct codeword the tested method has calculated if the method is set to return the cor. codew.
//			int[] correctCodeword = se.GeneratedDecodedInfo (codeword, mc.HCreator());
//			Console.WriteLine ("Correct Codeword:");
//			for (int i = 0; i < PropertyClass.PArray.GetLength (1)+PropertyClass.PArray.GetLength(0) ; i++) {
//				Console.Write (correctCodeword [i]);
//			}
//			Console.WriteLine ("");

			int[] errorVector = se.GeneratedDecodedInfo (codeword, mc.HCreator());
			Console.WriteLine ("Error Vector");
			for (int i = 0; i < PropertyClass.PArray.GetLength (1)+PropertyClass.PArray.GetLength(0) ; i++) {
				Console.Write (errorVector [i]);
			}
			Console.WriteLine ("");

			int[,] actualHMatrix = mc.HCreator ();
			Console.WriteLine ("Actual H matrix:");
			for (int i = 0; i < actualHMatrix.GetLength (0); i++) {
				for (int j = 0; j <actualHMatrix.GetLength (1); j++) {
					Console.Write(actualHMatrix [i, j]);
				}
				Console.WriteLine ("");
			}
		}
	}
}