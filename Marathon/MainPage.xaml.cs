﻿using Marathon.Model;
using Newtonsoft.Json;
namespace Marathon;

public partial class MainPage : ContentPage
{
    private RaceCollection RaceObject;
    public MainPage()
    {
        InitializeComponent();
        Title = "Marathon Manager";
        FillPicker();
    }

    public void FillPicker()
    {
        var client = new HttpClient(); 
        client.BaseAddress = new Uri("https://joewetzel.com/fvtc/marathon/");
        var Response = client.GetAsync("races/").Result;
        var wsJson = Response.Content.ReadAsStringAsync().Result;

        RaceObject = JsonConvert.DeserializeObject<RaceCollection>(wsJson);

        RacePicker.ItemsSource = RaceObject.races;

    }

    private void RacePicker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var SelectedRace = ((Picker)sender).SelectedIndex;
        var race_id = RaceObject.races[SelectedRace].id;

        var client = new HttpClient();
        client.BaseAddress = new Uri("https://joewetzel.com/fvtc/marathon/");
        var response = client.GetAsync("results/" + race_id).Result;
        var wsJson = response.Content.ReadAsStringAsync().Result;

        var ResultsObject = JsonConvert.DeserializeObject<ResultsCollection>(wsJson);

        var CellTemplate = new DataTemplate(typeof(TextCell));
        CellTemplate.SetBinding(TextCell.TextProperty, "name");
        CellTemplate.SetBinding(TextCell.DetailProperty, "detail");
        lstResults.ItemTemplate = CellTemplate;

        lstResults.ItemsSource = ResultsObject.results;
    }
}