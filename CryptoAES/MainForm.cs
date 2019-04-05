using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CryptoAES.Annotations;

namespace CryptoAES
{
    class MainForm : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly SecurityController _securityController = new SecurityController();

        public string Key
        {
            get => _key;
            set
            {
                _key = value;
                OnPropertyChanged();
            }
        }

        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged();
            }
        }

        public string Output
        {
            get => _output;
            set
            {
                _output = value;
                OnPropertyChanged();
            }
        }

        private string _output;
        private string _input;
        private string _key;

        public void Decrypt()
        {
            if (!IsValid)
            {
                return;
            }

            try
            {
                Output = _securityController.OpenSSLDecrypt(Input, Key);
            }
            catch (Exception e)
            {
                Output = "Le décryptage à échoué";
            }
        }

        public void Encrypt()
        {
            if (!IsValid)
            {
                return;
            }

            try
            {
                Output = _securityController.OpenSSLEncrypt(Input, Key);
            }
            catch (Exception e)
            {
                Output = "L'encryptage à échoué";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string Error { get; }

        public string this[string columnName] => Validate(columnName);

        private static readonly string[] ValidatedProperties = {"Key", "Input"};

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                {
                    if (Validate(property) != null)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private string Validate(string propertyName)
        {
            string validationMessage = null;

            switch (propertyName)
            {
                case "Key":
                    if (String.IsNullOrEmpty(Key))
                    {
                        validationMessage = "La clé est obligatoire";
                    }

                    break;
                case "Input":
                    if (String.IsNullOrEmpty(Input))
                    {
                        validationMessage = "Input is Null or empty";
                    }

                    break;
            }

            return validationMessage;
        }
    }
}