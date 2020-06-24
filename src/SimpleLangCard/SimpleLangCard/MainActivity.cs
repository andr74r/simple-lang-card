using System;
using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SimpleLangCard.Core.Cards;

namespace SimpleLangCard
{
    [Activity(
        Label = "@string/app_name", 
        Theme = "@style/AppTheme.NoActionBar", 
        MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private readonly CardManager _cardManager;
        private CardPool _cardPool;

        public MainActivity()
        {
            _cardManager = new CardManager();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _cardPool = _cardManager.GetCardPool();

            _cardPool.Shuffle();

            SetCard(_cardPool.NextCard());

            ShowButton.Click += (obj, e) => ShowTranslation();
            NextButton.Click += (obj, e) => NextCard();
        }


        private void ShowTranslation()
        {
            TranslationTextView.Visibility = ViewStates.Visible;
        }

        private void NextCard()
        {
            TranslationTextView.Visibility = ViewStates.Invisible;

            SetCard(_cardPool.NextCard());
        }

        private void SetCard(Card card)
        {
            OriginalTextView.Text = card.Original;

            TranslationTextView.Text = card.Translation;
        }

        private TextView TranslationTextView
        {
            get
            {
                return FindViewById<TextView>(Resource.Id.translation);
            }
        }

        private TextView OriginalTextView
        {
            get
            {
                return FindViewById<TextView>(Resource.Id.original);
            }
        }

        private Button ShowButton
        {
            get
            {
                return FindViewById<Button>(Resource.Id.showButton);
            }
        }

        private Button NextButton
        {
            get
            {
                return FindViewById<Button>(Resource.Id.nextButton);
            }
        }
    }
}
