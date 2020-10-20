


// ReSharper disable once ClassNeverInstantiated.Global
    namespace ProductInfoApi.EmailProviderService
    {
        public class EmailFormat
        {
            public EmailFormat(string customerName, string phoneNumber, string emailAddress, string interestedProducts)
            {
                CustomerName = customerName;
                _phoneNumber = phoneNumber;
                _interestedProducts = interestedProducts;
                CustomerEmailAddress = emailAddress;
                InitBodyOfEmail();
            }
            private void InitBodyOfEmail()
            {
                Body =
                    $"Customer Name: {CustomerName} \nPhone Number:{_phoneNumber} \nInterested Products:{_interestedProducts}";
            }

            private string CustomerName
            {
                get => _customerName;
                set
                {
                    _customerName = value;
                    UpdateSubject();
                }
            }

            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            private string CustomerEmailAddress { get; }

            private void UpdateSubject()
            {
                Subject = "Interest From Customer:" + CustomerName;
            }

            public string Subject;
            private readonly string _interestedProducts;
            private readonly string _phoneNumber;
            public string Body;
            private string _customerName;
        }
    }

