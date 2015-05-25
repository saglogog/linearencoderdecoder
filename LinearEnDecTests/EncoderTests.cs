using NUnit.Framework;
using System;
using LinearEnDecTests;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class EncoderTests
	{
		[Test ()]
		public void TestEncodeAndCodewordCreator()
		{
			MatrixCreatorTests mct = new MatrixCreatorTests ();
			string[,] matrix = mct.matrixFiller ();
			MatrixCreator mc = new MatrixCreator (matrix);
			int[,] PMatrix = mc.ReturnPMatrix ();
			int[] theWord = {0,1,1};
			Encoder enc = new Encoder(theWord, PMatrix);
			int[] extraBits = enc.Encode ();
			int[] codeword = enc.CodewordCreator ();
			for (int i = 0; i < PMatrix.GetLength (0); i++) {
				for (int j = 0; j < PMatrix.GetLength (1); j++) {
					Console.Write(PMatrix[i,j]);
						if(j==PMatrix.GetLength(1)-1){
							Console.Write("\n");
						}
				}
			}
			Console.WriteLine ("Death to The Heathens");
			for (int i = 0; i < PMatrix.GetLength (1); i++) {
				 Console.Write (extraBits [i]);
			}
			Console.Write ("\n");


			Console.WriteLine("Here comes the codeword!!!");
			for (int i = 0; i < PMatrix.GetLength (1)+PMatrix.GetLength(0); i++) {
				Console.Write (codeword[i]);
			}
			Console.Write ("\n");
		}

	}
}

