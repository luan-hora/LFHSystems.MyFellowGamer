using System;
using System.Collections.Generic;
using System.Text;

namespace LFHSystems.MyFellowGamer.Utils.Cryptography
{
    public static class Encryption
    {
        public static string EncodePasswordToBase64(string pPassword)
        {
            try
            {
                byte[] encData_byte = new byte[pPassword.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(pPassword);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro encrypting password: {ex.Message}");
            }
        }

        public static string DecodePasswordFromBase64(string pPassword)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(pPassword);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
