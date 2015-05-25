using System;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	public class MockSetupClass
	{
		public void matrixFiller(){
			Random rd = new Random ();
			PropertyClass pc = new PropertyClass ();
			int[,] theMatrix = new int[3, 4];
			for (int i = 0; i < 3; i++) {
				for (int k = 0; k < 4; k++) {
					theMatrix [i, k] = rd.Next ()%2;
				}
			}
			pc.PArray = theMatrix;
		}
	}
}