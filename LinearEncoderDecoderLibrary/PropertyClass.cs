using System;

namespace LinearEncoderDecoderLibrary
{
	public class PropertyClass
	{
		public PropertyClass ()
		{
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

		private int[,] pArray;
		public int[,] PArray
		{
				
			get {
				return pArray;
			}
			set {
				pArray = value;
			}
		}
	}
}

