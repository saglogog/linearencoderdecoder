using System;

namespace LinearEncoderDecoderLibrary
{
	//----perhaps use static class instead of singleton?-------
	// Answer: the basic reason that a singleton implementation is used over a static class is that
	//I will most probably need to pass the singleton class propert

	//This class is made using the Singleton pattern so that "there can be only one" pArray instance,
	//and thus all classes using it will not have to reinitialize the class and not be able to find the
	//value given initially to the pArray.
	public static class PropertyClass
	{	
		//automatic property
		public static int[,] PArray{ get; set; }
	}
}

