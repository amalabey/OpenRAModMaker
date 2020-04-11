﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			 
			var modsPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods";
			var workingDirectoryPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA";

			var mod = new Mod(workingDirectoryPath, modsPath, "ra");
			this.DataContext = mod.Manifest;
		}
	}
}
