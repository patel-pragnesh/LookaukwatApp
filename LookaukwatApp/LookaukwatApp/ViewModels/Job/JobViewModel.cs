﻿using LookaukwatApp.Helpers;
using LookaukwatApp.Services;
using LookaukwatApp.ViewModels.Image;
using LookaukwatApp.ViewModels.StaticList;
using LookaukwatApp.Views.ImageView;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LookaukwatApp.ViewModels.Job
{
    public class JobViewModel : BaseViewModel
    {
       
        ApiServices _apiServices = new ApiServices();
        public IList<string> ContractList { get; }
        public IList<string> ActivitysectorList { get; }
        public IList<string> SearchOrSaskList { get; }
        public IList<string> TownList { get; }

        private int id;
        public int Id
        {
            get => id;
            set => id = value;
        }
        private string titleJob;
        public string TitleJob
        {
            get => titleJob;
            set => SetProperty(ref titleJob, value);
        }
        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        private string town;
        public string Town
        {
            get => town;
            set => SetProperty(ref town, value);
        }
        private string street;
        public string Street
        {
            get => street;
            set => SetProperty(ref street, value);
        }
        private int price;
        public int Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        private string searchOrAskJob;
        public string SearchOrAskJob
        {
            get => searchOrAskJob;
            set => SetProperty(ref searchOrAskJob, value);
        }
        private string typeContract;
        public string TypeContract
        {
            get => typeContract;
            set => SetProperty(ref typeContract, value);
        }
        private string activitySector;
        public string ActivitySector
        {
            get => activitySector;
            set 
            { 
                SetProperty(ref activitySector, value);
                if (value != "Autre")
                {
                    SearchrText = "Je recherche un emploi de " + value;
                    OfferText = "J'offre un emploi de " + value;
                }
            }
        }

        private bool ValidateLoging()
        {
            return !String.IsNullOrWhiteSpace(TitleJob)
                && !String.IsNullOrWhiteSpace(Description)
                && !String.IsNullOrWhiteSpace(Street)
                && !String.IsNullOrWhiteSpace(ActivitySector)
                && !String.IsNullOrWhiteSpace(TypeContract);
        }


        private bool isOffer = true;
        public bool IsOffer
        {
            get { return isOffer; }
            set
            {
                SetProperty(ref isOffer, value);

                if (value == true)
                {
                    IsSearch = false;
                    SearchOrAskJob = "J'offre";
                }
            }
        }
        private bool isSearch = false;

        public bool IsSearch
        {
            get { return isSearch; }
            set
            {
                SetProperty(ref isSearch, value);

                if (value == true)
                {
                    IsOffer = false;
                    SearchOrAskJob = "Je recherche";

                }
            }
        }

        private string offerText = "J'offre du travail / prestation de service";
        public string OfferText
        {
            get => offerText;
            set => SetProperty(ref offerText, value);
        }

        private string searchText = "Je recherche du travail / prestation de service";
        public string SearchrText
        {
            get => searchText;
            set => SetProperty(ref searchText, value);
        }

        public JobViewModel()
        {
            PostJobCommad = new Command(OnPostJob, ValidateLoging);
            TitlePage = "Titre, salaire, description...";
            ContractList = StaticListViewModel.GetWorkContratTypeList;
            ActivitysectorList = StaticListViewModel.GetActivitySectortList;
            TownList = StaticListViewModel.GetTownCameroonList;
            SearchOrSaskList = StaticListViewModel.OfferOSearchList;
            this.PropertyChanged +=
               (_, __) => PostJobCommad.ChangeCanExecute();
        }

        public Command PostJobCommad { get; }

        async void OnPostJob()
        {
            //var coor = await _apiServices.GetCoodinateAsync(Town, Street);
            IsRunning = true;
            var accessToken = Settings.AccessToken;
            var ProductId = await _apiServices.JobPostAsync(accessToken, TitleJob, Description, Town, Street, Price, SearchOrAskJob, TypeContract, ActivitySector);
            if (ProductId != 0)
            {
                IsRunning = false;
                Id = ProductId;
                await Shell.Current.GoToAsync($"{nameof(UploadImagePage)}?{nameof(UploadImageViewModel.ItemId)}={ProductId}");

            }
        }


    }
}
