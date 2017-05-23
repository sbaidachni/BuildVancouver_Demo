using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input.Inking;
using Windows.UI.Input.Inking.Analysis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InkDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        InkPresenter inkPresenter;
        InkAnalyzer inkAnalyzer;

        public MainPage()
        {
            this.InitializeComponent();

            inkAnalyzer = new InkAnalyzer();
            inkPresenter = inkCanvas.InkPresenter;
            inkPresenter.StrokesCollected += InkPresenter_StrokesCollected;
            inkPresenter.StrokesErased += InkPresenter_StrokesErased;

        }

        private void InkPresenter_StrokesErased(InkPresenter sender, InkStrokesErasedEventArgs args)
        {
            var ids = from a in args.Strokes select a.Id;
            inkAnalyzer.RemoveDataForStrokes(ids);
        }

        private void InkPresenter_StrokesCollected(InkPresenter sender, InkStrokesCollectedEventArgs args)
        {
            inkAnalyzer.AddDataForStrokes(args.Strokes);
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var res=await inkAnalyzer.AnalyzeAsync();
            if (res.Status==InkAnalysisStatus.Updated)
            {
                StringBuilder bl = new StringBuilder();
                var nodes=inkAnalyzer.AnalysisRoot.FindNodes(InkAnalysisNodeKind.InkWord);
                foreach(InkAnalysisInkWord node in nodes)
                {
                    bl.Append(node.RecognizedText);
                    bl.Append(' ');
                }
                displayText.Text = bl.ToString();
            }
        }
    }
}
