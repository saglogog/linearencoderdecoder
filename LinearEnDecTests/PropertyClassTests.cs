using NUnit.Framework;
using System;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	/// <summary>
	/// Property class tests. This classes tests are made so that they check if the property classes' 
	/// properties can be used by multiple classes or not. Does a new instance of the property class
	/// have the correct value for the pArray property or not?
	/// </summary>
	[TestFixture ()]
	public class PropertyClassTests
	{
		readonly MockSetupClass setup = new MockSetupClass();
		[Test ()]
		public void TestCase ()
		{
			//--PropertyClass pc = new PropertyClass ();
			//--int[,] pArray = pc.PArray;
			int[,] matrix = setup.FillMatrix ();
			int[,] pArray = PropertyClass.PArray;

			Console.WriteLine ();
			for (int i = 0; i < PropertyClass.PArray.GetLength (0); i++) {
				for (int j = 0; j <	PropertyClass.PArray.GetLength (1); j++) {
					Console.Write (PropertyClass.PArray [i, j]);
				}
				Console.WriteLine ();
			}

			Assert.AreEqual (matrix, pArray);
		}
	}
}

