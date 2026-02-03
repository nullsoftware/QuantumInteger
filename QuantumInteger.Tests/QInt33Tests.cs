namespace QuantumInteger.Tests
{
    public class QInt33Tests
    {
        [Fact]
        public void TestEncryption()
        {
            string input = "Hello, Quantum Integer!";
            byte[] inputData = System.Text.Encoding.UTF8.GetBytes(input);
            int len = inputData.Length / 5;

            if (inputData.Length - len > 0)
            {
                len += 5;
            }

            QInt33 key = new QInt33(12345678901); // encryption key
            MemoryStream memoryStream = new MemoryStream();
            for (int i = 0; i < len - 5; i++)
            {
                QInt33 dataChunk = new QInt33(inputData, i);
                QInt33 encryptedChunk = dataChunk * key;
                byte[] encryptedBytes = encryptedChunk.ToBinary();
                memoryStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            }

            byte[] encryptedData = memoryStream.ToArray();
            string result = Convert.ToBase64String(inputData);

            Assert.Equal("SGVsbG8sIFF1YW50dW0gSW50ZWdlciE=", result);
        }
    }
}