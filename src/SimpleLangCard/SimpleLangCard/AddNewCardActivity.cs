using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using SimpleLangCard.Core.Cards;
using SimpleLangCard.Data;

namespace SimpleLangCard
{
    [Activity(
        Label = "@string/app_name",
        Theme = "@style/AppTheme.NoActionBar",
        MainLauncher = false)]
    class AddNewCardActivity : Activity
    {
        private readonly CardManager _cardManager;

        public AddNewCardActivity()
        {
            _cardManager = new CardManager(new CardRepository());
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_add_new_card);

            BackButton.Click += (obj, e) => Back();
            AddButton.Click += (obj, e) => AddCard();
        }

        private void Back()
        {
            StartActivity(new Intent(this, typeof(MainActivity)));
        }

        private void AddCard()
        {
            if (!string.IsNullOrEmpty(Original.Text) && !string.IsNullOrEmpty(Translation.Text))
            {
                _cardManager.Add(Original.Text, Translation.Text);

                Back();
            }
        }

        private Button BackButton
        {
            get
            {
                return FindViewById<Button>(Resource.Id.back_button);
            }
        }

        private Button AddButton
        {
            get
            {
                return FindViewById<Button>(Resource.Id.addButton);
            }
        }

        private EditText Original
        {
            get
            {
                return FindViewById<EditText>(Resource.Id.original);
            }
        }

        private EditText Translation
        {
            get
            {
                return FindViewById<EditText>(Resource.Id.translation);
            }
        }
    }
}