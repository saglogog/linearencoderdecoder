using System;

namespace LinearEncoderDecoderLibrary
{
	public class MatrixCreator
	{
		string[,] PMatrix;
		int[,] intPMatrix;
		int [,] IkMatrix;
		/// <summary>
		/// Initializes a new instance of the <see cref="LinearEncoderDecoderLibrary.MatrixCreator"/> class.
		/// </summary>
		/// <param name="P">The user given matrix P</param>
		public MatrixCreator(string[,] P)
		{
			PMatrix = P;
			intPMatrix = TwoDimArrayConverter (PMatrix);

		}

		private int[,] TwoDimArrayConverter(string[,] matrix)
		{
			int[,] twoDimArray = new int[matrix.GetLength(0),matrix.GetLength(1)];
			for (int i = 0; i < matrix.GetLength(0); i++) {
				for (int k = 0; k < matrix.GetLength (1); k++) {
					twoDimArray [i,k] = Convert.ToInt32 (matrix [i,k]);
				}
			}
			return twoDimArray;
		}
			
		public int[,] IdentityArrayCreator(int k){
			int[,] identityArray = new int[k, k];
			for (int i = 0; i < k; i++) {
				identityArray [i, i] = 1;
			}
			return identityArray;
		}

		public int[] GCreator(){
			throw(NotImplementedException);
		}
	}
}

