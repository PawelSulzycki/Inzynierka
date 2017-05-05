using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.AspNet.SignalR.Client;
using System.Collections.Generic;
using Android.Graphics;


namespace LightControl
{
    [Activity(Label = "LightControl", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        HubConnection communicationConnection;
        IHubProxy SignalRCommunicationHub;

        private static int[] message = new int[5];

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            communicationConnection = new HubConnection("http://controllight.azurewebsites.net");
            SignalRCommunicationHub = communicationConnection.CreateHubProxy("communication");

            Button buttonKitchen = FindViewById<Button>(Resource.Id.buttonKitchen);
            Button buttonBathroom = FindViewById<Button>(Resource.Id.buttonBathroom);
            Button buttonLivingRoom = FindViewById<Button>(Resource.Id.buttonLivingRoom);
            Button buttonBedroom = FindViewById<Button>(Resource.Id.buttonBedroom);
            Button buttonAttic = FindViewById<Button>(Resource.Id.buttonAttic);
            Button[] buttonName = 
            {
                buttonKitchen,buttonBathroom,buttonLivingRoom,buttonBedroom,buttonAttic
            };
            JoinCommunication();
            //message
            SignalRCommunicationHub.On<int[]>("ShowCurrent", (index)=>
            {
                
                RunOnUiThread(() =>
                {
                    message = index;
                    for (int i = 0; i < message.Length; i++)
                    {
                    ChangeButton(buttonName[i],i);

                    }
                });
            });

            buttonKitchen.Click += delegate
            {
                ActionClickButton(buttonName[0],0);
            };
            buttonBathroom.Click += delegate
            {
                ActionClickButton(buttonName[1], 1);
            };
            buttonLivingRoom.Click += delegate
            {
                ActionClickButton(buttonName[2], 2);
            };
            buttonBedroom.Click += delegate
            {
                ActionClickButton(buttonName[3], 3);
            };
            buttonAttic.Click += delegate
            {
                ActionClickButton(buttonName[4], 4);
            };

        }
        public async virtual void JoinCommunication()
        {
            try
            {
                await communicationConnection.Start();
            }
            catch (Exception)
            {
                // Do some error handling.
            }
        }

        public async virtual void SendCurrent(int index, int current)
        {
            await SignalRCommunicationHub.Invoke("SendCurrent", index, current);
        }

        public void ChangeButton(Button buttonName, int index)
        {
            if (message[index] == 0)
            {
                buttonName.SetBackgroundColor(Color.Green);
                buttonName.SetTextColor(Color.Black);
                buttonName.Text = "Zapal swiatlo";
            }
            else
            {
                buttonName.SetBackgroundColor(Color.Red);
                buttonName.SetTextColor(Color.White);
                buttonName.Text = "Zgas swiatlo";
            }
        }

        public void ActionClickButton(Button buttonName, int index)
        {
            if (communicationConnection.State == ConnectionState.Connected)
            {
                if (message[index] == 0)
                {
                    buttonName.SetBackgroundColor(Color.Red);
                    buttonName.SetTextColor(Color.White);
                    buttonName.Text = "Zgas swiatlo";

                    SendCurrent(index, 1);
                }
                else
                {
                    buttonName.SetBackgroundColor(Color.Green);
                    buttonName.SetTextColor(Color.Black);
                    buttonName.Text = "Zapal swiatlo";
                    SendCurrent(index, 0);
                }

            }
            else
            {
                buttonName.Text = "Nie Polaczono";
            }
        }

    }
}

