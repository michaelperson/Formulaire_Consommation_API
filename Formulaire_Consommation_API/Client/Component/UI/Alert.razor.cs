﻿using Formulaire_Consommation_API.Client.Services.Interfaces;
using Formulaire_Consommation_API.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Component.UI
{
    public class AlertBase: ComponentBase, IDisposable
    {
        [Inject]
  IAlertService AlertService { get; set;  }
        [Inject]
        NavigationManager NavigationManager{ get; set; }
        [Parameter]
        public string Id { get; set; } = "default-alert";

        [Parameter]
        public bool Fade { get; set; } = true;

        protected List<Formulaire_Consommation_API.Shared.Alert> alerts = new List<Formulaire_Consommation_API.Shared.Alert>();

        protected override void OnInitialized()
        {
            // subscribe to new alerts and location change events
            AlertService.OnAlert += OnAlert;
            NavigationManager.LocationChanged += OnLocationChange;
        }

        public void Dispose()
        {
            // unsubscribe from alerts and location change events
            AlertService.OnAlert -= OnAlert;
            NavigationManager.LocationChanged -= OnLocationChange;
        }

        protected async void OnAlert(Formulaire_Consommation_API.Shared.Alert alert)
        {
            // ignore alerts sent to other alert components
            if (alert.Id != Id)
                return;

            // clear alerts when an empty alert is received
            if (alert.Message == null)
            {
                // remove alerts without the 'KeepAfterRouteChange' flag set to true
                alerts.RemoveAll(x => !x.KeepAfterRouteChange);

                // set the 'KeepAfterRouteChange' flag to false for the
                // remaining alerts so they are removed on the next clear
                alerts.ForEach(x => x.KeepAfterRouteChange = false);
            }
            else
            {
                // add alert to array
                alerts.Add(alert);
                StateHasChanged();

                // auto close alert if required
                if (alert.AutoClose)
                {
                    await Task.Delay(3000);
                    RemoveAlert(alert);
                }
            }

            StateHasChanged();
        }

        protected void OnLocationChange(object sender, LocationChangedEventArgs e)
        {
            AlertService.Clear(Id);
        }

        protected async void RemoveAlert(Formulaire_Consommation_API.Shared.Alert alert)
        {
            // check if already removed to prevent error on auto close
            if (!alerts.Contains(alert)) return;

            if (Fade)
            {
                // fade out alert
                alert.Fade = true;

                // remove alert after faded out
                await Task.Delay(250);
                alerts.Remove(alert);
            }
            else
            {
                // remove alert
                alerts.Remove(alert);
            }

            StateHasChanged();
        }

        protected string CssClass(Formulaire_Consommation_API.Shared.Alert alert)
        {
            if (alert == null) return null;

            var classes = new List<string> { "alert", "alert-dismissable", "mt-4", "container" };

            var alertTypeClass = new Dictionary<AlertType, string>();
            alertTypeClass[AlertType.Success] = "alert-success";
            alertTypeClass[AlertType.Error] = "alert-danger";
            alertTypeClass[AlertType.Info] = "alert-info";
            alertTypeClass[AlertType.Warning] = "alert-warning";

            classes.Add(alertTypeClass[alert.Type]);

            if (alert.Fade)
                classes.Add("fade");

            return string.Join(' ', classes);
        }
    }
}
