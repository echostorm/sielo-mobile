﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sielo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SActionBar : ContentView
	{
	    public event EventHandler<LoadRequestEventArgs> LoadRequest;
	    public event EventHandler GoBack;
	    public event EventHandler GoForward;
	    public event EventHandler ShowTabs;

        public SActionBar ()
		{
			InitializeComponent ();

		    urlBar.SearchButtonPressed += OnUrlEntered;
		    btnBack.Clicked += OnGoBackClicked;
		    btnForward.Clicked += OnGoForwardClicked;
		    btnTabs.Clicked += OnShowTabsClicked;
		}

	    public void SetUrl(string url)
	    {
	        urlBar.Text = url;
	    }

	    private void OnGoBackClicked(object sender, EventArgs e)
	    {
	        var handler = GoBack;
            handler?.Invoke(this, new EventArgs());
	    }

	    private void OnGoForwardClicked(object sender, EventArgs e)
	    {
	        var handler = GoForward;
	        handler?.Invoke(this, new EventArgs());
	    }

	    private void OnShowTabsClicked(object sender, EventArgs e)
	    {
	        var handler = ShowTabs;
            handler?.Invoke(this, new EventArgs());
	    }

        private void OnUrlEntered(object sender, EventArgs args)
	    {
	        var url = urlBar.Text;

            // TODO: differencie search and url

	        if (!url.StartsWith("http") || !url.StartsWith("https"))
	            url = "https://" + url;

	        var loadRequestEventArgs = new LoadRequestEventArgs
	        {
	            Url = url
	        };

	        var handler = LoadRequest;
	        handler?.Invoke(this, loadRequestEventArgs);

	    }
	}

    public class LoadRequestEventArgs : EventArgs
    {
        public string Url { get; set; }
    }
}