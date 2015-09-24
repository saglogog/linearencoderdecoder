using System;
using Gtk;

namespace LinearEncoderDecoderInterface
{
	class MainClass
	{
		
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}