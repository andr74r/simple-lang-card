﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SimpleLangCard.Core.Cards;
using SimpleLangCard.Data;

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
            _cardManager = new CardManager(new CardRepository());
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _cardPool = _cardManager.GetCardPool();

            if (_cardPool.HasCards())
            {
                _cardPool.Shuffle();

                SetCard(_cardPool.NextCard());
            }

            ShowButton.Click += (obj, e) => ShowTranslation();
            NextButton.Click += (obj, e) => NextCard();

            AddButton.Click += (obj, e) => AddCard();
            DeleteButton.Click += (obj, e) => DeleteCard();
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
            OriginalTextView.Text = card?.Original;

            TranslationTextView.Text = card?.Translation;
        }

        private void AddCard()
        {
            StartActivity(new Intent(this, typeof(AddNewCardActivity)));
        }

        private void DeleteCard()
        {
            if (_cardPool.HasCards())
            {
                _cardManager.DeleteCard(_cardPool.Current);

                _cardPool = _cardManager.GetCardPool();

                _cardPool.Shuffle();

                if (_cardPool.HasCards())
                {
                    SetCard(_cardPool.NextCard());
                }
            }
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

        private Button AddButton
        {
            get
            {
                return FindViewById<Button>(Resource.Id.addButton);
            }
        }

        private Button DeleteButton
        {
            get
            {
                return FindViewById<Button>(Resource.Id.deleteButton);
            }
        }
    }
}
