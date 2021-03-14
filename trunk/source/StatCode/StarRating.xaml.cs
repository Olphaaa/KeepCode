using ProjectClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StatCode
{
    /// <summary>
    /// Logique d'interaction pour StarRating.xaml
    /// </summary>
    public partial class StarRating : UserControl
    {
        static StarRating()
        {
            NiveauDifProperty = DependencyProperty.Register("NiveauDif", typeof(int), typeof(StarRating), new PropertyMetadata(0, new PropertyChangedCallback(OnStarRatingChanged)));
        }
        public StarRating()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d">DependencyObject</param>
        /// <param name="e">DependencyPropertyChangedEventArgs</param>
        private static void OnStarRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            if (((StarRating)d).NiveauDif == 0)
            {
                ((StarRating)d).star1.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star2.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star3.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star4.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star5.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
            }
            if (((StarRating)d).NiveauDif == 1)
            {
                ((StarRating)d).star1.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star2.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star3.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star4.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star5.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
            }
            if (((StarRating)d).NiveauDif == 2)
            {
                ((StarRating)d).star1.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star2.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star3.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star4.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star5.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
            }
            if (((StarRating)d).NiveauDif == 3)
            {
                ((StarRating)d).star1.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star2.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star3.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star4.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star5.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
            }
            if (((StarRating)d).NiveauDif == 4)
            {
                ((StarRating)d).star1.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star2.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star3.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star4.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star5.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
            }
            if (((StarRating)d).NiveauDif == 5)
            {
                ((StarRating)d).star1.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star2.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star3.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star4.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
                ((StarRating)d).star5.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
            }
        }



        //public int StarNote
        //{
        //    get { return (int)GetValue(StarNoteProperty); }
        //    set
        //    {
        //        SetValue(StarNoteProperty, value);
        //        Debug.WriteLine(value);
        //        if (value == 0)
        //        {
        //            star1.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            star2.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            star3.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            star4.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            star5.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            TxtNote.Text = value.ToString();
        //        }
        //        if (value == 1)
        //        {
        //            star1.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star2.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            star3.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            star4.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            star5.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            TxtNote.Text = value.ToString();
        //        }
        //        if (value == 2)
        //        {
        //            star1.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star2.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star3.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            star4.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            star5.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            TxtNote.Text = value.ToString();
        //        }
        //        if (value == 3)
        //        {
        //            star1.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star2.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star3.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star4.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            star5.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            TxtNote.Text = value.ToString();
        //        }
        //        if (value == 4)
        //        {
        //            star1.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star2.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star3.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star4.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star5.Source = new BitmapImage(new Uri("img/icon/Star_W.png", UriKind.RelativeOrAbsolute));
        //            TxtNote.Text = value.ToString();
        //        }
        //        if (value == 5)
        //        {
        //            star1.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star2.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star3.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star4.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            star5.Source = new BitmapImage(new Uri("img/icon/Star_R.png", UriKind.RelativeOrAbsolute));
        //            TxtNote.Text = value.ToString();
        //        }
        //    }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty StarNoteProperty;


        public static readonly DependencyProperty NiveauDifProperty;

        public int NiveauDif
        {
            get
            {
                return (int)GetValue(StarRating.NiveauDifProperty);
            }
            set
            {

                SetValue(StarRating.NiveauDifProperty, value);

            }
        }
    }
}