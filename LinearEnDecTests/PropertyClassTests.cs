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

			Assert.AreEqual (matrix, pArray);
		}
	}
}

