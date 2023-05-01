﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EccobankAdmin.VistaModelo
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //Escribir en los textbox o entrys
        public event PropertyChangedEventHandler PropertyChanged;
        //Para navegar entre paginas
        public INavigation Navigation;
        public void OnpropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ImageSource foto;
        public ImageSource Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                OnpropertyChanged();
            }
        }
        //comportamiento para displayalert
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);

        }
        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        //Comportamiento para seleccionar en listas
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field,value))
            {
                return false;
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetProperty(ref _isBusy, value);
            }
        }

        protected void SetValue<T>(ref T backingFieled,T value,[CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingFieled,value))
            {
                return;
            }
            backingFieled = value;

            OnPropertyChanged(propertyName);
        }
    }
}
