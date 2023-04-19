using MVVMGroceryStoreApp.Models.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMGroceryStoreApp.Models
{
    public class AuthorizationModel
    {
        private string SecureStringToString(SecureString secureString)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
        public Аккаунт AccountValidation(string login, SecureString securePassword)
        {
            if (string.IsNullOrEmpty(login) || securePassword.Length < 1)
            {
                MessageBox.Show("Введите логин и пароль");
                return null;
            }

            Аккаунт selectedAccount = GroceryStoreDatabase.GetContext().Аккаунт.FirstOrDefault(x => x.Логин.Equals(login));

            if (selectedAccount != null && VerifyHashedPassword(selectedAccount.Пароль, SecureStringToString(securePassword)))
            {
                return selectedAccount;
            }
            return null;
        }
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] passwordArray;
            byte[] source = Convert.FromBase64String(hashedPassword);
            if ((source.Length != 49) || (source[0] != 0))
            {
                return false;
            }
            byte[] salt = new byte[16];
            Buffer.BlockCopy(source, 1, salt, 0, 16);
            byte[] hashedPasswordArray = new byte[32];
            Buffer.BlockCopy(source, 17, hashedPasswordArray, 0, 32);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, salt, 1000))
            {
                passwordArray = bytes.GetBytes(32);
            }

            return ByteArraysEqual(hashedPasswordArray, passwordArray);
        }

        public static bool ByteArraysEqual(byte[] firstByteArray, byte[] secondByteArray)
        {
            if (firstByteArray == secondByteArray) return true;
            if (firstByteArray == null || secondByteArray == null) return false;
            if (firstByteArray.Length != secondByteArray.Length) return false;
            for (int i = 0; i < firstByteArray.Length; i++)
            {
                if (firstByteArray[i] != secondByteArray[i]) return false;
            }
            return true;
        }

    }
}
