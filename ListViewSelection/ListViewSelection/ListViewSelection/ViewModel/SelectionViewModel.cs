using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomSelection
{
    public class SelectionViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<MusicInfo> musicInfo;
        private ImageSource selectionEdit;
        private ImageSource selectionCancel;
        private string headerInfo;
        private string titleInfo;
        private bool isVisible;

        #endregion

        #region Constructor

        public SelectionViewModel()
        {
            GenerateSource();
            titleInfo = "Music Library";
            headerInfo = "";
            selectionEdit = ImageSource.FromResource("ListViewSelection.Images.SelectionEdit.png");
            selectionCancel = ImageSource.FromResource("ListViewSelection.Images.SelectionCancel.png");
        }

        #endregion

        #region Properties

        public ObservableCollection<MusicInfo> MusicInfo
        {
            get { return musicInfo; }
            set { this.musicInfo = value; }
        }

        public string TitleInfo
        {
            get { return titleInfo; }
            set
            {
                if (titleInfo != value)
                {
                    titleInfo = value;
                    OnPropertyChanged("TitleInfo");
                }
            }
        }

        public string HeaderInfo
        {
            get { return headerInfo; }
            set
            {
                if (headerInfo != value)
                {
                    headerInfo = value;
                    OnPropertyChanged("HeaderInfo");
                }
            }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged("IsVisible");
                }
            }
        }

        public ImageSource SelectionEdit
        {
            get
            {
                return selectionEdit;
            }
            set
            {
                if (selectionEdit != value)
                {
                    selectionEdit = value;
                    OnPropertyChanged("SelectionEdit");
                }
            }
        }

        public ImageSource SelectionCancel
        {
            get
            {
                return selectionCancel;
            }
            set
            {
                if (selectionCancel != value)
                {
                    selectionCancel = value;
                    OnPropertyChanged("SelectionCancel");
                }
            }
        }

        #endregion

        #region Generate Source

        private async void GenerateSource()
        {
            var random = new Random();
            musicInfo = new ObservableCollection<MusicInfo>();

            await Task.Delay(1000);
            for (int i = 0; i < SongsNames.Count(); i++)
            {
                var info = new MusicInfo()
                {
                    SongTitle = SongsNames[i],
                    SongAuther = SongAuthers[i],
                    SongSize = random.Next(50, 600).ToString() + "." + random.Next(1, 10) / 2 + "KB",
                    SongThumbnail = ImageSource.FromResource("ListViewSelection.Images.SongThumbnail.png"),
                    SelectedImage = ImageSource.FromResource("ListViewSelection.Images.Selected.png"),
                    NotSelectedImage = ImageSource.FromResource("ListViewSelection.Images.NotSelected.png"),
                };
                musicInfo.Add(info);
            }
        }

        #endregion

        #region SongInfo

        string[] SongsNames = new string[]
        {
            "Adventure of a lifetime",
            "Blue moon of Kentucky",
            "I don't care if tomorrow never comes",
            "You are the first, my last, my everything",
            "Words don't come easy to me",
            "Everybody's free to wear sunscreen",
            "Before the next teardrop falls",
            "You've lost that lovin' feeling",
            "Underneath your clothes",
            "Try to remember",
            "The hanging tree",
            "Somewhere over the rainbow",
            "Return to innocence",
            "I say a little prayer for you",
            "I believe I can fly",
            "House every weekend",
            "Heal the world",
            "Green green grass of home",
            "God only knows",
            "Five hundred miles",
            "Earth song",
            "Down to the river to pray",
            "Come away with me",
            "Boulevard of broken dreams",
            "Heart is a drum",
            "I'm so lonesome I could cry",
        };

        string[] SongAuthers = new string[]
        {
            "Coldplay",
            "Bill Monroe",
            "Hank Williams & George Jones",
            "Barry White",
            "F. R. David",
            "Baz Luhrmann",
            "Freddy Fender",
            "Righteous Brothers",
            "Shakira",
            "Andy Williams",
            "James Newton Howard ft. Jennifer Lawrence",
            "I. Kamakawiwo'ole",
            "Enigma",
            "Dionne Warwick",
            "R. Kelly",
            "David Zowie",
            "Michael Jackson",
            "Tom Jones",
            "The Beach Boys",
            "The Brothers Four",
            "Michael Jackson",
            "Alison Krauss",
            "Norah Jones",
            "Green Day",
            "Beck",
            "Hank Williams",
        };

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
