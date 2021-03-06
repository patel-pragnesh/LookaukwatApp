﻿using LookaukwatApp.Models;
using LookaukwatApp.Services;
using LookaukwatApp.ViewModels.StaticList;
using LookaukwatApp.Views.SearchView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace LookaukwatApp.ViewModels.Search
{
    
    public class SearchViewModel : BaseViewModel
    {
        ApiServices _apiServices = new ApiServices();


        //For every Product
        #region Same model for every categorie
        private int result = 0;
        public int Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }


        public IList<string> SearchOrSaskList { get; }
        public IList<string> Categoryliste { get; }
        public IList<string> TownList { get; }
        private string category;
        public string Categori
        {
            get { return category; }
            set
            {

                SetProperty(ref category, value);
                NumberOfResult();
            }
        }

        private string searchAndResultText = "Rechercher";
        public string SearchAndResultText
        {
            get { return searchAndResultText; }
            set
            {

                SetProperty(ref searchAndResultText, value);

            }
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

        private string town;
        public string Town
        {
            get { return town; }
            set
            {
                SetProperty(ref town, value);
                NumberOfResult();
            }

        }


        private string searchOrAskJob;
        public string SearchOrAskJob
        {
            get { return searchOrAskJob; }
            set
            {
                SetProperty(ref searchOrAskJob, value);
                NumberOfResult();
            }

        }
        #endregion same model
        // For Appart Model

        #region Appart Model
        public IList<string> TypeList { get; }
        public IList<string> FurnitureOrNotList { get; }

        private int priceApart = 100000000;
        public int PriceApart
        {
            get { return priceApart; }
            set
            {
                SetProperty(ref priceApart, value);
                NumberOfResult();
            }
        }

        private string typeAppart;
        public string TypeAppart
        {
            get { return typeAppart; }
            set
            {
                SetProperty(ref typeAppart, value);
                NumberOfResult();
            }
        }
        private string furnitureOrNotAppart;
        public string FurnitureOrNotAppart
        {
            get { return furnitureOrNotAppart; }
            set
            {
                SetProperty(ref furnitureOrNotAppart, value);
                NumberOfResult();
            }
        }

        private int roomNumberAppart = 10;
        public int RoomNumberAppart
        {
            get { return roomNumberAppart; }
            set
            {
                SetProperty(ref roomNumberAppart, value);
                NumberOfResult();
            }
        }

        private int apartSurfaceAppart = 2000;
        public int ApartSurfaceAppart
        {
            get { return apartSurfaceAppart; }
            set
            {
                SetProperty(ref apartSurfaceAppart, value);
                NumberOfResult();
            }
        }
        #endregion Apart Model

        //For House
        #region House

        ObservableCollection<string> Housetypes = new ObservableCollection<string>();
        public ObservableCollection<string> HouseTypes { get => Housetypes; set => SetProperty(ref Housetypes, value); }

        ObservableCollection<string> fabricMaterials = new ObservableCollection<string>();
        public ObservableCollection<string> FabricMaterials { get => fabricMaterials; set => SetProperty(ref fabricMaterials, value); }

        private void UpdateHouseTypelist(string rubrique)
        {
            HouseTypes.Clear();
            FabricMaterials.Clear();

            switch (rubrique)
            {
                case "Ameublement":
                    foreach (var list in TypeAmebleumentHouseList)
                    {
                        HouseTypes.Add(list);
                    }
                    foreach (var fabric in FabricMaterialAmmeblementDecorationList)
                    {
                        FabricMaterials.Add(fabric);
                    }

                    break;
                case "Electroménager":

                    break;
                case "Cuisine":
                    foreach (var list in TypeOutilTableHouseList)
                    {
                        HouseTypes.Add(list);
                    }

                    foreach (var fabric in FabricMaterialOutilTableList)
                    {
                        FabricMaterials.Add(fabric);
                    }
                    break;
                case "Décoration":
                    foreach (var list in TypeDecorationHouseList)
                    {
                        HouseTypes.Add(list);
                    }

                    foreach (var fabric in FabricMaterialAmmeblementDecorationList)
                    {
                        FabricMaterials.Add(fabric);
                    }
                    break;
                case "Linge de maison":
                    foreach (var list in TypeLingeHouseList)
                    {
                        HouseTypes.Add(list);
                    }

                    foreach (var fabric in FabricMaterialLingeList)
                    {
                        FabricMaterials.Add(fabric);
                    }
                    break;
                case "Bricolage":

                    break;
                case "Jardinage":

                    break;
            }
        }



        public IList<string> HouseRubriqueList { get; }
        public IList<string> TypeAmebleumentHouseList { get; }
        public IList<string> TypeOutilTableHouseList { get; }
        public IList<string> TypeDecorationHouseList { get; }
        public IList<string> TypeLingeHouseList { get; }
        public IList<string> FabricMaterialAmmeblementDecorationList { get; }
        public IList<string> FabricMaterialOutilTableList { get; }
        public IList<string> FabricMaterialLingeList { get; }
        public IList<string> HouseColorList { get; }
        public IList<string> HouseStateList { get; }

        private int priceHouse = 100000;
        public int PriceHouse
        {
            get { return priceHouse; }
            set
            {
                SetProperty(ref priceHouse, value);
                NumberOfResult();
            }
        }

        private string typeHouse;
        public string TypeHouse
        {
            get { return typeHouse; }
            set
            {
                SetProperty(ref typeHouse, value);
                NumberOfResult();
            }
        }
        private string rubriqueHouse;
        public string RubriqueHouse
        {
            get
            {
                return rubriqueHouse;
            }
            set
            {
                SetProperty(ref rubriqueHouse, value);
                UpdateHouseTypelist(value);
                NumberOfResult();
            }

        }

        private string fabricMaterialHouse;
        public string FabricMaterialHouse
        {
            get { return fabricMaterialHouse; }
            set
            {
                SetProperty(ref fabricMaterialHouse, value);
                NumberOfResult();
            }
        }


        private string stateHouse;
        public string StateHouse
        {
            get { return stateHouse; }
            set
            {
                SetProperty(ref stateHouse, value);
                NumberOfResult();
            }
        }

        private string colorHouse;
        public string ColorHouse
        {
            get { return colorHouse; }
            set
            {
                SetProperty(ref colorHouse, value);
                NumberOfResult();
            }
        }
        #endregion House

        //For Job Model
        #region Job
        public IList<string> ContractList { get; }
        public IList<string> ActivitysectorList { get; }

        private int priceJob = 100000000;
        public int PriceJob
        {
            get { return priceJob; }
            set
            {
                SetProperty(ref priceJob, value);
                NumberOfResult();
            }
        }

        private string typeContract;
        public string TypeContract
        {
            get { return typeContract; }
            set
            {
                SetProperty(ref typeContract, value);
                NumberOfResult();
            }
        }
        private string activitySector;
        public string ActivitySector
        {
            get { return activitySector; }
            set
            {
                SetProperty(ref activitySector, value);
                NumberOfResult();
            }
        }
        #endregion Job

        // For Mode category
        #region Mode
        ObservableCollection<string> types = new ObservableCollection<string>();
        public ObservableCollection<string> Types { get => types; set => SetProperty(ref types, value); }

        ObservableCollection<string> brands = new ObservableCollection<string>();
        public ObservableCollection<string> Brands { get => brands; set => SetProperty(ref brands, value); }

        ObservableCollection<string> sizes = new ObservableCollection<string>();
        public ObservableCollection<string> Sizes { get => sizes; set => SetProperty(ref sizes, value); }

        private void UpdateTypelist(string rubrique)
        {
            try
            {


                Types.Clear();
                Brands.Clear();
                Sizes.Clear();
                switch (rubrique)
                {
                    case "Vêtements":
                        foreach (var list in TypeClothesList)
                        {
                            Types.Add(list);
                        }
                        foreach (var brand in BrandClothesList)
                        {
                            Brands.Add(brand);
                        }
                        foreach (var size in SizeClothesList)
                        {
                            Sizes.Add(size);
                        }
                        break;
                    case "Chaussures":
                        foreach (var list in TypeShoesList)
                        {
                            Types.Add(list);
                        }
                        foreach (var brand in BrandShoesList)
                        {
                            Brands.Add(brand);
                        }
                        foreach (var size in SizeShoesList)
                        {
                            Sizes.Add(size);
                        }
                        break;
                    case "Accesoires & Bagagerie":
                        foreach (var list in TypeAccesorieLugagesList)
                        {
                            Types.Add(list);
                        }

                        foreach (var brand in BrandClothesList)
                        {
                            Brands.Add(brand);
                        }
                        break;
                    case "Montres & Bijoux":
                        foreach (var list in TypeWatchJewelryList)
                        {
                            Types.Add(list);
                        }

                        foreach (var brand in BrandClothesList)
                        {
                            Brands.Add(brand);
                        }
                        break;
                    case "Equipement bébé":
                        foreach (var list in TypeBabyEquipmentList)
                        {
                            Types.Add(list);
                        }

                        foreach (var brand in BrandClothesList)
                        {
                            Brands.Add(brand);
                        }
                        break;
                    case "Vêtements bébé":
                        foreach (var list in TypeBabyClothesList)
                        {
                            Types.Add(list);
                        }

                        foreach (var brand in BrandClothesList)
                        {
                            Brands.Add(brand);
                        }
                        foreach (var size in SizeClothesList)
                        {
                            Sizes.Add(size);
                        }
                        break;
                }
            }catch(Exception e) { Console.WriteLine(e); }
        }



        public IList<string> TypeClothesList { get; }
        public IList<string> TypeShoesList { get; }
        public IList<string> TypeAccesorieLugagesList { get; }
        public IList<string> TypeWatchJewelryList { get; }
        public IList<string> TypeBabyEquipmentList { get; }
        public IList<string> TypeBabyClothesList { get; }
        public IList<string> RubriqueList { get; }
        public IList<string> BrandClothesList { get; }
        public IList<string> BrandShoesList { get; }
        public IList<string> UniversList { get; }
        public IList<string> SizeClothesList { get; }
        public IList<string> SizeShoesList { get; }
        public IList<string> ColorList { get; }
        public IList<string> StateList { get; }

        private int priceMode = 100000000;
        public int PriceMode
        {
            get { return priceMode; }
            set
            {
                SetProperty(ref priceMode, value);
                NumberOfResult();
            }
        }

        private string typeMode;
        public string TypeMode
        {
            get { return typeMode; }
            set
            {
                SetProperty(ref typeMode, value);
                NumberOfResult();
            }
        }
        private string rubriqueMode;
        public string RubriqueMode
        {
            get
            {
                return rubriqueMode;
            }
            set
            {
                SetProperty(ref rubriqueMode, value);
                try
                {
                    UpdateTypelist(value);
                    NumberOfResult();
                }catch(Exception ex) { Console.WriteLine(ex); }
                
            }

        }

        private string brandMode;
        public string BrandMode
        {
            get { return brandMode; }
            set
            {
                SetProperty(ref brandMode, value);
                NumberOfResult();
            }
        }

        private string universMode;
        public string UniversMode
        {
            get { return universMode; }
            set
            {
                SetProperty(ref universMode, value);
                NumberOfResult();
            }
        }

        private string sizeMode;
        public string SizeMode
        {
            get { return sizeMode; }
            set
            {
                SetProperty(ref sizeMode, value);
                NumberOfResult();
            }
        }

        private string state;
        public string State
        {
            get { return state; }
            set
            {
                SetProperty(ref state, Uri.UnescapeDataString(value));
                NumberOfResult();
            }
        }

        private string colorMode;
        public string ColorMode
        {
            get { return colorMode; }
            set
            {
                SetProperty(ref colorMode, Uri.UnescapeDataString(value));
                NumberOfResult();
            }
        }
        #endregion Mode

        //Multimedia model
        #region Multimedia
        ObservableCollection<string> Multimediamodels = new ObservableCollection<string>();
        public ObservableCollection<string> MultimediaModels { get => Multimediamodels; set => SetProperty(ref Multimediamodels, value); }

        ObservableCollection<string> Multimediabrands = new ObservableCollection<string>();
        public ObservableCollection<string> MultimediaBrands { get => Multimediabrands; set => SetProperty(ref Multimediabrands, value); }


        private void UpdateBrandlist(string rubrique)
        {
            MultimediaModels.Clear();
            MultimediaBrands.Clear();

            switch (rubrique)
            {
                case "Informatique":

                    foreach (var brand in BrandInformatiquePhotocopyMultimediaList)
                    {
                        MultimediaBrands.Add(brand);
                    }
                    foreach (var model in ModelInformatiquePhotocopyMultimediaList)
                    {
                        MultimediaModels.Add(model);
                    }

                    break;
                case "Consoles de jeux":

                    foreach (var brand in BrandConsoleGamequeMultimediaList)
                    {
                        Brands.Add(brand);
                    }
                    foreach (var model in ModelConsoleGameMultimediaList)
                    {
                        MultimediaModels.Add(model);
                    }
                    break;
                case "Jeux video":

                    foreach (var brand in BrandConsoleGamequeMultimediaList)
                    {
                        MultimediaBrands.Add(brand);
                    }
                    foreach (var model in ModelConsoleGameMultimediaList)
                    {
                        MultimediaModels.Add(model);
                    }
                    break;
                case "Téléphonie":

                    foreach (var brand in BrandPhoneAccesorieMultimediaList)
                    {
                        MultimediaBrands.Add(brand);
                    }
                    break;
                case "Accésoires téléphonie":

                    foreach (var brand in BrandPhoneAccesorieMultimediaList)
                    {
                        MultimediaBrands.Add(brand);
                    }

                    break;
                case "Téléviseur":


                    foreach (var brand in BrandTVGameMultimediaList)
                    {
                        MultimediaBrands.Add(brand);
                    }

                    foreach (var model in ModelTVGameMultimediaList)
                    {
                        MultimediaModels.Add(model);
                    }
                    break;
                case "Son":

                    foreach (var brand in BrandSonMultimediaList)
                    {
                        MultimediaBrands.Add(brand);
                    }

                    foreach (var model in ModelSonGamequeMultimediaList)
                    {
                        MultimediaModels.Add(model);
                    }
                    break;
                case "Image & Camera vidéo":


                    foreach (var brand in BrandInformatiquePhotocopyMultimediaList)
                    {
                        MultimediaBrands.Add(brand);
                    }
                    foreach (var model in ModelInformatiquePhotocopyMultimediaList)
                    {
                        MultimediaModels.Add(model);
                    }
                    break;
                case "Photocopieuse":

                    foreach (var brand in BrandInformatiquePhotocopyMultimediaList)
                    {
                        MultimediaBrands.Add(brand);
                    }
                    foreach (var model in ModelInformatiquePhotocopyMultimediaList)
                    {
                        MultimediaModels.Add(model);
                    }
                    break;
            }
        }

        private void UpdateModellist(string brand, string rubrique)
        {
            try
            {

           if(MultimediaModels != null)
                {
                    MultimediaModels.Clear();
                }
            
                if (rubrique == "Téléphonie")
                {

                    switch (brand)
                    {
                        case "Apple":
                            foreach (var model in ModelApplePhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Huawei":
                            foreach (var model in ModelHuaweiPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Samsung":
                            foreach (var model in ModelSamsungPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Sony":
                            foreach (var model in ModelSonyPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Alcatel":
                            foreach (var model in ModelAlcatelPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Asus":
                            foreach (var model in ModelAzusPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Honor":
                            foreach (var model in ModelHonorPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "HTC":
                            foreach (var model in ModelHTCPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Lenovo":
                            foreach (var model in ModelLenovoPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "LG":
                            foreach (var model in ModelLGPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Microsoft":
                            foreach (var model in ModelMicrosoftPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Motorola":
                            foreach (var model in ModelMotorolaPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Nokia":
                            foreach (var model in ModelMicrosoftPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "One plus":
                            foreach (var model in ModelOnePlusPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Wiko":
                            foreach (var model in ModelWikoPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Xaomi":
                            foreach (var model in ModelXaomiPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "ZTE":
                            foreach (var model in ModelZTEPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        default:
                            MultimediaModels.Add("Autre");
                            break;
                    }
                }
                else if (rubrique == "Accésoires téléphonie")
                {
                    MultimediaModels.Clear();
                    switch (brand)
                    {
                        case "Apple":
                            foreach (var model in ModelApplePhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Huawei":
                            foreach (var model in ModelHuaweiPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Samsung":
                            foreach (var model in ModelSamsungPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Sony":
                            foreach (var model in ModelSonyPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Alcatel":
                            foreach (var model in ModelAlcatelPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Asus":
                            foreach (var model in ModelAzusPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Honor":
                            foreach (var model in ModelHonorPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "HTC":
                            foreach (var model in ModelHTCPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Lenovo":
                            foreach (var model in ModelLenovoPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "LG":
                            foreach (var model in ModelLGPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Microsoft":
                            foreach (var model in ModelMicrosoftPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Motorola":
                            foreach (var model in ModelMotorolaPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Nokia":
                            foreach (var model in ModelMicrosoftPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "One plus":
                            foreach (var model in ModelOnePlusPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Wiko":
                            foreach (var model in ModelWikoPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "Xaomi":
                            foreach (var model in ModelXaomiPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        case "ZTE":
                            foreach (var model in ModelZTEPhoneAccesorieMultimediaList)
                            {
                                MultimediaModels.Add(model);
                            }
                            break;
                        default:
                            MultimediaModels.Add("Autre");
                            break;
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        public IList<string> MultimediaRubriqueList { get; }
        public IList<string> BrandInformatiquePhotocopyMultimediaList { get; }
        public IList<string> BrandConsoleGamequeMultimediaList { get; }
        public IList<string> BrandPhoneAccesorieMultimediaList { get; }
        public IList<string> BrandTVGameMultimediaList { get; }
        public IList<string> BrandSonMultimediaList { get; }
        public IList<string> ModelInformatiquePhotocopyMultimediaList { get; }
        public IList<string> ModelConsoleGameMultimediaList { get; }
        public IList<string> ModelApplePhoneAccesorieMultimediaList { get; }
        public IList<string> ModelHuaweiPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelSamsungPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelSonyPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelAlcatelPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelAzusPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelHonorPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelHTCPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelLenovoPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelMicrosoftPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelLGPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelMotorolaPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelOnePlusPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelWikoPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelXaomiPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelZTEPhoneAccesorieMultimediaList { get; }
        public IList<string> ModelTVGameMultimediaList { get; }
        public IList<string> ModelSonGamequeMultimediaList { get; }
        public IList<string> CapacityMultimediaList { get; }

        private int priceMulti = 100000000;
        public int PriceMulti
        {
            get { return priceMulti; }
            set
            {
                SetProperty(ref priceMulti, value);
                NumberOfResult();
            }
        }

        private string Multimediarubrique;
        public string MultimediaRubrique
        {
            get
            {
                return Multimediarubrique;
            }
            set
            {
                SetProperty(ref Multimediarubrique, value);
                UpdateBrandlist(value);
                NumberOfResult();
            }

        }

        private string Multimediabrand;
        public string MultimediaBrand
        {
            get
            {
                return Multimediabrand;
            }
            set
            {
                SetProperty(ref Multimediabrand, value);
                try
                {
                    UpdateModellist(value, MultimediaRubrique);
                    NumberOfResult();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
               
            }
        }


        private string multimediaModel;
        public string MultimediaModel
        {
            get { return multimediaModel; }
            set
            {
                SetProperty(ref multimediaModel, value);
                NumberOfResult();
            }
        }

        private string Multimediacapacity;
        public string MultimediaCapacity
        {
            get { return Multimediacapacity; }
            set
            {
                SetProperty(ref Multimediacapacity, value);
                NumberOfResult();
            }
        }
        #endregion Multimedia

        //Vehicule rubrique
        #region Vehicule

        ObservableCollection<string> Vehiculebrands = new ObservableCollection<string>();
        public ObservableCollection<string> VehiculeBrands { get => Vehiculebrands; set => SetProperty(ref Vehiculebrands, value); }

        ObservableCollection<string> Vehiculemodels = new ObservableCollection<string>();
        public ObservableCollection<string> VehiculeModels { get => Vehiculemodels; set => SetProperty(ref Vehiculemodels, value); }

        private void UpdateVehiculeTypelist(string rubrique)
        {

            VehiculeBrands.Clear();
            VehiculeModels.Clear();
            switch (rubrique)
            {
                case "Voitures":

                    foreach (var brand in BrandVehiculeAutoList)
                    {
                        VehiculeBrands.Add(brand);
                    }

                    break;
                case "Location voitures":
                    foreach (var brand in BrandVehiculeAutoList)
                    {
                        VehiculeBrands.Add(brand);
                    }

                    break;
                case "Motos":
                    foreach (var brand in BrandVehiculeMotoList)
                    {
                        VehiculeBrands.Add(brand);
                    }
                    break;
                case "Equipement Auto":
                    foreach (var brand in BrandVehiculeAutoList)
                    {
                        VehiculeBrands.Add(brand);
                    }


                    break;
                case "Equipement Moto":
                    foreach (var brand in BrandVehiculeMotoList)
                    {
                        VehiculeBrands.Add(brand);
                    }
                    break;

            }
        }

        private void UpdateVehiculeModellist(string brand, string rubrique)
        {
            if (rubrique == "Voitures" || rubrique == "Location voitures")
            {
                VehiculeModels.Clear();
                switch (brand)
                {
                    case "Toyota":
                        foreach (var model in ModelVehiculeAutoToyotaList)
                        {
                            VehiculeModels.Add(model);
                        }
                        break;
                    case "Mercedes":
                        foreach (var model in ModelVehiculeAutoMercedesList)
                        {
                            VehiculeModels.Add(model);
                        }
                        break;
                    case "Hyundrai":
                        foreach (var model in ModelVehiculeAutoHyundaiList)
                        {
                            VehiculeModels.Add(model);
                        }
                        break;
                    case "Mazda":
                        foreach (var model in ModelVehiculeAutoMazdaList)
                        {
                            VehiculeModels.Add(model);
                        }
                        break;
                    case "Kia":
                        foreach (var model in ModelVehiculeAutoKiaList)
                        {
                            VehiculeModels.Add(model);
                        }
                        break;
                    default:
                        GetEquipmentModel(rubrique, brand);
                        break;
                }
            }else if(rubrique == "Equipement Auto" || rubrique == "Equipement Moto")
            {
                VehiculeModels.Clear();

                GetEquipmentModel(rubrique, brand);
                
            }
        }



        public IList<string> RubriqueVehiculeList { get; }
        public IList<string> BrandVehiculeAutoList { get; }
        public IList<string> BrandVehiculeMotoList { get; }
        public IList<string> ModelVehiculeAutoToyotaList { get; }
        public IList<string> ModelVehiculeAutoHyundaiList { get; }
        public IList<string> ModelVehiculeAutoMercedesList { get; }
        public IList<string> ModelVehiculeAutoMazdaList { get; }
        public IList<string> ModelVehiculeAutoKiaList { get; }
        public IList<string> TypeVehiculeAutoList { get; }
        public IList<string> PetrolVehiculeList { get; }
        public IList<string> NumberOfDoorVehiculeList { get; }
        public IList<string> ColorVehiculeList { get; }
        public IList<string> GearBoxVehiculeList { get; }
        public IList<string> StateVehiculeList { get; }

        private int priceVehicule = 100000000;
        public int PriceVehicule
        {
            get { return priceVehicule; }
            set
            {
                SetProperty(ref priceVehicule, value);
                NumberOfResult();
            }
        }

        private string Vehiculerubrique;
        public string VehiculeRubrique
        {
            get
            {
                return Vehiculerubrique;
            }
            set
            {
                SetProperty(ref Vehiculerubrique, value);
                UpdateVehiculeTypelist(value);
                NumberOfResult();
            }

        }

        private string Vehiculebrand;
        public string VehiculeBrand
        {
            get
            {
                return Vehiculebrand;
            }
            set
            {
                SetProperty(ref Vehiculebrand, value);
                UpdateVehiculeModellist(value, VehiculeRubrique);
                NumberOfResult();
            }
        }

        private string Vehiculemodel;
        public string VehiculeModel
        {
            get { return Vehiculemodel; }
            set
            {
                SetProperty(ref Vehiculemodel,value);
                NumberOfResult();
            }
        }

        private string Vehiculetype;
        public string VehiculeType
        {
            get { return Vehiculetype; }
            set
            {
                SetProperty(ref Vehiculetype, value);
                NumberOfResult();
            }
        }

        private string petrol;
        public string Petrol
        {
            get { return petrol; }
            set
            {
                SetProperty(ref petrol, value);
                NumberOfResult();
            }
        }

        private int year = 2021;
        public int Year
        {
            get { return year; }
            set
            {
                SetProperty(ref year, value);
                NumberOfResult();
            }
        }

        private int mileage = 300000;
        public int Mileage
        {
            get { return mileage; }
            set
            {
                SetProperty(ref mileage, value);
                NumberOfResult();
            }
        }

        private string numberOfDoor;
        public string NumberOfDoor
        {
            get { return numberOfDoor; }
            set
            {
                SetProperty(ref numberOfDoor, value);
                NumberOfResult();
            }
        }
        private string gearBox;
        public string GearBox
        {
            get { return gearBox; }
            set
            {
                SetProperty(ref gearBox, value);
                NumberOfResult();
            }
        }
        private string Vehiculestate;
        public string VehiculeState
        {
            get { return Vehiculestate; }
            set
            {
                SetProperty(ref Vehiculestate, value);
                NumberOfResult();
            }
        }

        private string color;
        public string Color
        {
            get { return color; }
            set
            {
                SetProperty(ref color, value);
                NumberOfResult();
            }
        }
        #endregion Vehicule


        public Command SearchCommand { get; }
        //Constuctor
        public SearchViewModel()
        {
            TitlePage = "Plus de filtres";
            // for every search categori
            SearchOrSaskList = StaticListViewModel.OfferOSearchList;
            Categoryliste = StaticListViewModel.GetCategoryListSearch;
            TownList = StaticListViewModel.GetTownCameroonListSearch;

            //Search command
            SearchCommand = new Command(OnSearch);

            // for Appart
            #region Appart
            TypeList = StaticListViewModel.GetListApartTypeSearch;
            FurnitureOrNotList = StaticListViewModel.GetListFurnitureOrNotSearch;
            #endregion

            // For House
            #region House
            HouseRubriqueList = StaticListHouseViewModel.GetRubriqueHouseListtSearch;
            TypeAmebleumentHouseList = StaticListHouseViewModel.GetTypeAmebleumentHouseListSearch;
            TypeOutilTableHouseList = StaticListHouseViewModel.GetTypeOutilTableHouseListSearch;
            TypeDecorationHouseList = StaticListHouseViewModel.GetTypeDecorationHouseListSearch;
            TypeLingeHouseList = StaticListHouseViewModel.GetTypeLingeHouseListSearch;
            FabricMaterialAmmeblementDecorationList = StaticListHouseViewModel.GetFabricMaterialAmmeblementDecorationListSearch;
            FabricMaterialOutilTableList = StaticListHouseViewModel.GetFabricMaterialOutilTableListSearch;
            FabricMaterialLingeList = StaticListHouseViewModel.GetFabricMaterialLingeListSearch;
            HouseColorList = StaticListModeViewModel.GetColorModeListSearch;
            HouseStateList = StaticListHouseViewModel.GetStateHouseListSearch;
            #endregion

            // For Job
            #region Job
            ContractList = StaticListViewModel.GetWorkContratTypeListSearch;
            ActivitysectorList = StaticListViewModel.GetActivitySectortListSearch;
            #endregion

            //For Mode
            #region Mode
            TypeAccesorieLugagesList = StaticListModeViewModel.GetTypeAccesorieLugagesListSearch;
            TypeBabyClothesList = StaticListModeViewModel.GetTypeBabyClothesListSearch;
            TypeBabyEquipmentList = StaticListModeViewModel.GetTypeBabyEquipmentListSearch;
            TypeClothesList = StaticListModeViewModel.GetTypeClothesListSearch;
            TypeShoesList = StaticListModeViewModel.GetTypeShoesListSearch;
            TypeWatchJewelryList = StaticListModeViewModel.GetTypeWatchJewelryList;
            RubriqueList = StaticListModeViewModel.GetRubriqueModeListSearch;
            BrandClothesList = StaticListModeViewModel.GetBrandClothesListSearch;
            BrandShoesList = StaticListModeViewModel.GetBrandShoesListSearch;
            UniversList = StaticListModeViewModel.GetUniversListSearch;
            SizeClothesList = StaticListModeViewModel.GetSeizeClothesListSearch;
            SizeShoesList = StaticListModeViewModel.GetSizeShoesListSearch;
            ColorList = StaticListModeViewModel.GetColorModeListSearch;
            StateList = StaticListModeViewModel.GetStateModeListSearch;
            #endregion

            // For Multimedia
            #region Multimedia

            MultimediaRubriqueList = StaticListMultimediaViewModel.GetTypeMultimediaListSearch;
            BrandConsoleGamequeMultimediaList = StaticListMultimediaViewModel.GetBrandConsoleGamequeMultimediaListSearch;
            BrandInformatiquePhotocopyMultimediaList = StaticListMultimediaViewModel.GetBrandInformatiquePhotocopyMultimediaListSearch;
            BrandTVGameMultimediaList = StaticListMultimediaViewModel.GetBrandTVGameMultimediaListSearch;
            BrandSonMultimediaList = StaticListMultimediaViewModel.GetBrandSonMultimediaListSearch;
            BrandPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetBrandPhoneAccesorieMultimediaListSearch;
            ModelInformatiquePhotocopyMultimediaList = StaticListMultimediaViewModel.GetModelInformatiquePhotocopyMultimediaListSearch;
            ModelConsoleGameMultimediaList = StaticListMultimediaViewModel.GetModelConsoleGameMultimediaListSearch;
            ModelApplePhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelApplePhoneAccesorieMultimediaListSearch;
            ModelHuaweiPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelHuaweiPhoneAccesorieMultimediaListSearch;
            ModelSamsungPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelSamsungPhoneAccesorieMultimediaListSearch;
            ModelSonyPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelSonyPhoneAccesorieMultimediaListSearch;
            ModelAlcatelPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelAlcatelPhoneAccesorieMultimediaListSearch;
            ModelAzusPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelAzusPhoneAccesorieMultimediaListSearch;
            ModelHonorPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelHonorPhoneAccesorieMultimediaListSearch;
            ModelHTCPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelHTCPhoneAccesorieMultimediaListSearch;
            ModelLenovoPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelLenovoPhoneAccesorieMultimediaListSearch;
            ModelMicrosoftPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelMicrosoftPhoneAccesorieMultimediaListSearch;
            ModelLGPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelLGPhoneAccesorieMultimediaListSearch;
            ModelMotorolaPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelMotorolaPhoneAccesorieMultimediaListSearch;
            ModelOnePlusPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelOnePlusPhoneAccesorieMultimediaListSearch;
            ModelWikoPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelWikoPhoneAccesorieMultimediaListSearch;
            ModelXaomiPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelXaomiPhoneAccesorieMultimediaListSearch;
            ModelZTEPhoneAccesorieMultimediaList = StaticListMultimediaViewModel.GetModelZTEPhoneAccesorieMultimediaListSearch;
            ModelTVGameMultimediaList = StaticListMultimediaViewModel.GetModelTVGameMultimediaListSearch;
            ModelSonGamequeMultimediaList = StaticListMultimediaViewModel.GetModelSonGamequeMultimediaListSearch;
            CapacityMultimediaList = StaticListMultimediaViewModel.GetCapacityMultimediaListSearch;
            #endregion

            // For vehicule
            #region vehicule
            RubriqueVehiculeList = StaticListVehiculeViewModel.GetRubriqueVehiculeListSearch;
            BrandVehiculeAutoList = StaticListVehiculeViewModel.GetBrandVehiculeAutoListSearch;
            BrandVehiculeMotoList = StaticListVehiculeViewModel.GetBrandVehiculeMotoListSearch;
            ModelVehiculeAutoToyotaList = StaticListVehiculeViewModel.GetModelVehiculeAutoToyotaListSearch;
            ModelVehiculeAutoHyundaiList = StaticListVehiculeViewModel.GetModelVehiculeAutoHyundaiListSearch;
            ModelVehiculeAutoMercedesList = StaticListVehiculeViewModel.GetModelVehiculeAutoMercedesListSearch;
            ModelVehiculeAutoMazdaList = StaticListVehiculeViewModel.GetModelVehiculeAutoMazdaListSearch;
            ModelVehiculeAutoKiaList = StaticListVehiculeViewModel.GetModelVehiculeAutoKiaListSearch;
            TypeVehiculeAutoList = StaticListVehiculeViewModel.GetTypeVehiculeAutoListSearch;
            PetrolVehiculeList = StaticListVehiculeViewModel.GetPetrolVehiculeListSearch;
            NumberOfDoorVehiculeList = StaticListVehiculeViewModel.GetNumberOfDoorVehiculeListSearch;
            ColorVehiculeList = StaticListVehiculeViewModel.GetColorVehiculeListSearch;
            GearBoxVehiculeList = StaticListVehiculeViewModel.GetGearBoxVehiculeListSearch;
            StateVehiculeList = StaticListVehiculeViewModel.GetStateVehiculeListSearch;

            #endregion


        }

        private async void NumberOfResult()
        {
            try
            {


                switch (SearchOrAskJob)
                {
                    case "J'offre":

                        switch (Categori)
                        {

                            case "Emploi":
                                TitlePage = "Plus de filtres dans Emploi";
                                Result = await _apiServices.GetResultOfferSeachNumberJobAsync(Categori, Town, SearchOrAskJob, TypeContract, ActivitySector, PriceJob);

                                SearchAndResultText = "Rechercher" +Environment.NewLine + Result + " annonces";
                                break;
                            case "Immobilier":
                                TitlePage = "Plus de filtres dans Immobilier";
                                Result = await _apiServices.GetResultOfferSeachNumberApartAsync(Categori, Town, SearchOrAskJob, PriceApart, RoomNumberAppart,
                                    FurnitureOrNotAppart, TypeAppart, ApartSurfaceAppart);

                                SearchAndResultText = "Rechercher" + Environment.NewLine + Result + " annonces";

                                break;
                            case "Multimédia":
                                TitlePage = "Plus de filtres dans Multimédia";
                                Result = await _apiServices.GetResultOfferSeachNumberMultiAsync("Multimedia", Town, SearchOrAskJob, PriceMulti, MultimediaRubrique,
                                    MultimediaBrand, MultimediaModel, MultimediaCapacity);

                                SearchAndResultText = "Rechercher" + Environment.NewLine + Result + " annonces";

                                break;
                            case "Maison":
                                TitlePage = "Plus de filtres dans Maison";
                                Result = await _apiServices.GetResultOfferSeachNumberHouseAsync(Categori, Town, SearchOrAskJob, PriceHouse, RubriqueHouse, TypeHouse,
                                    FabricMaterialHouse, StateHouse, ColorHouse);

                                SearchAndResultText = "Rechercher" + Environment.NewLine + Result + " annonces";

                                break;
                            case "Mode":
                                TitlePage = "Plus de filtres dans Mode";
                                Result = await _apiServices.GetResultOfferSeachNumberModeAsync(Categori, Town, SearchOrAskJob, PriceMode, RubriqueMode, TypeMode,
                                    BrandMode, UniversMode, SizeMode, State, ColorMode);

                                SearchAndResultText = "Rechercher" + Environment.NewLine + Result + " annonces";

                                break;
                            case "Véhicule":
                                TitlePage = "Plus de filtres dans Véhicule";
                                Result = await _apiServices.GetResultOfferSeachNumberVehiculeAsync("Vehicule", Town, SearchOrAskJob, PriceVehicule, VehiculeRubrique, VehiculeBrand, VehiculeModel,
                                    VehiculeType, Petrol, Year, Mileage, NumberOfDoor, GearBox, Vehiculestate, Color);

                                SearchAndResultText = "Rechercher" + Environment.NewLine + Result + " annonces";

                                break;

                            default:
                                Result = await _apiServices.GetResultAskAndOfferSeachNumberAsync(Categori, Town, SearchOrAskJob); ;
                                SearchAndResultText = "Rechercher" + Environment.NewLine + Result + " annonces";
                                break;
                        }

                        break;

                    case "Je recherche":

                        Result = await _apiServices.GetResultAskAndOfferSeachNumberAsync(Categori, Town, SearchOrAskJob);

                        SearchAndResultText = "Rechercher" + Environment.NewLine + Result + " annonces";
                        break;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        private async void OnSearch()
        {
            string JsonSearchModel = null;
            switch (SearchOrAskJob)
            {
                case "J'offre":

                    switch (Categori)
                    {

                        case "Emploi":

                            SearchModel searchModel = new SearchModel
                            {
                                Category = Categori,
                                Town = Town,
                                SearchOrAskJob = SearchOrAskJob,
                                TypeContract = TypeContract,
                                ActivitySector = ActivitySector,
                                PriceJob = PriceJob
                            };
                            JsonSearchModel = JsonConvert.SerializeObject(searchModel); 

                             await Shell.Current.GoToAsync($"{nameof(ResultSearchPage)}?{nameof(ResultSearchViewModel.JsonSearchModel)}={JsonSearchModel}&{nameof(ResultSearchViewModel.NumberOfresult)}={Result}");

                            break;
                        case "Immobilier":


                            SearchModel searchModelImo = new SearchModel
                            {
                                Category = Categori,
                                Town = Town,
                                SearchOrAskJob = SearchOrAskJob,
                                PriceApart = PriceApart,
                                RoomNumberAppart = RoomNumberAppart,
                                FurnitureOrNotAppart = FurnitureOrNotAppart,
                                TypeAppart = TypeAppart,
                                ApartSurfaceAppart = ApartSurfaceAppart

                            };
                            JsonSearchModel = JsonConvert.SerializeObject(searchModelImo);

                            await Shell.Current.GoToAsync($"{nameof(ResultSearchPage)}?{nameof(ResultSearchViewModel.JsonSearchModel)}={JsonSearchModel}&{nameof(ResultSearchViewModel.NumberOfresult)}={Result}");


                            break;
                        case "Multimédia":


                            SearchModel searchModelMulti = new SearchModel
                            {
                                Category = "Multimedia",
                                Town = Town,
                                SearchOrAskJob = SearchOrAskJob,
                                PriceMulti = PriceMulti,
                                MultimediaRubrique = MultimediaRubrique,
                                MultimediaBrand = MultimediaBrand,
                                MultimediaModel = MultimediaModel,
                                MultimediaCapacity = MultimediaCapacity

                            };
                            JsonSearchModel = JsonConvert.SerializeObject(searchModelMulti);

                            await Shell.Current.GoToAsync($"{nameof(ResultSearchPage)}?{nameof(ResultSearchViewModel.JsonSearchModel)}={JsonSearchModel}&{nameof(ResultSearchViewModel.NumberOfresult)}={Result}");


                            break;
                        case "Maison":

                            SearchModel searchModelHouse = new SearchModel
                            {
                                Category = Categori,
                                Town = Town,
                                SearchOrAskJob = SearchOrAskJob,
                                PriceHouse = PriceHouse,
                                RubriqueHouse = RubriqueHouse,
                                TypeHouse = TypeHouse,
                                FabricMaterialHouse = FabricMaterialHouse,
                                StateHouse = StateHouse,
                                ColorHouse = ColorHouse

                            };

                            JsonSearchModel = JsonConvert.SerializeObject(searchModelHouse);

                            await Shell.Current.GoToAsync($"{nameof(ResultSearchPage)}?{nameof(ResultSearchViewModel.JsonSearchModel)}={JsonSearchModel}&{nameof(ResultSearchViewModel.NumberOfresult)}={Result}");


                            break;
                        case "Mode":


                            SearchModel searchModelMode = new SearchModel
                            {
                                Category = Categori,
                                Town = Town,
                                SearchOrAskJob = SearchOrAskJob,
                                PriceMode = PriceMode,
                                RubriqueMode = RubriqueMode,
                                TypeMode = TypeMode,
                                BrandMode = BrandMode,
                                UniversMode = UniversMode,
                                SizeMode = SizeMode,
                                State = State,
                                ColorMode = ColorMode

                            };

                            JsonSearchModel = JsonConvert.SerializeObject(searchModelMode);
                            string data = HttpUtility.UrlEncode(JsonSearchModel);
                            await Shell.Current.GoToAsync($"{nameof(ResultSearchPage)}?{nameof(ResultSearchViewModel.JsonSearchModel)}={data}&{nameof(ResultSearchViewModel.NumberOfresult)}={Result}");


                            break;
                        case "Véhicule":

                            SearchModel searchModelVehicule = new SearchModel
                            {
                                Category = "Vehicule",
                                Town = Town,
                                SearchOrAskJob = SearchOrAskJob,
                                PriceVehicule = PriceVehicule,
                                VehiculeRubrique = VehiculeRubrique,
                                VehiculeBrand = VehiculeBrand,
                                VehiculeModel = VehiculeModel,
                                VehiculeType = VehiculeType,
                                Petrol = Petrol,
                                Year = Year.ToString(),
                                Mileage = Mileage.ToString(),
                                NumberOfDoor = NumberOfDoor,
                                GearBox = GearBox,
                                VehiculeState = Vehiculestate,
                                Color = Color

                            };

                            JsonSearchModel = JsonConvert.SerializeObject(searchModelVehicule);

                            await Shell.Current.GoToAsync($"{nameof(ResultSearchPage)}?{nameof(ResultSearchViewModel.JsonSearchModel)}={JsonSearchModel}&{nameof(ResultSearchViewModel.NumberOfresult)}={Result}");


                            break;

                        default:

                            SearchModel searchModelOffer = new SearchModel
                            {
                                Category = Categori,
                                Town = Town,
                                SearchOrAskJob = SearchOrAskJob,

                            };
                            JsonSearchModel = JsonConvert.SerializeObject(searchModelOffer);

                            await Shell.Current.GoToAsync($"{nameof(ResultSearchPage)}?{nameof(ResultSearchViewModel.JsonSearchModel)}={JsonSearchModel}&{nameof(ResultSearchViewModel.NumberOfresult)}={Result}");


                            break;
                    }

                    break;

                case "Je recherche":

                    SearchModel searchModelSearch = new SearchModel
                    {
                        Category = Categori,
                        Town = Town,
                        SearchOrAskJob = SearchOrAskJob,

                    };
                    JsonSearchModel = JsonConvert.SerializeObject(searchModelSearch);

                    await Shell.Current.GoToAsync($"{nameof(ResultSearchPage)}?{nameof(ResultSearchViewModel.JsonSearchModel)}={JsonSearchModel}&{nameof(ResultSearchViewModel.NumberOfresult)}={Result}");


                    break;
            }

        }

        private async void GetEquipmentModel(string rubrique, string brand)
        {
           var liste =  await _apiServices.GetVehiculeEquipementModelAsync(rubrique, brand);
            foreach (var model in liste)
            {
                VehiculeModels.Add(model);
            }
        }
    }
}
