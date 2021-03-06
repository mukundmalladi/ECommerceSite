﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceMvc.Models
{
    public class FullCheckOutModel : CreditCardInformation
    {

        //[OptionalValidation]
        public int ZipCode { get; set; }

     
     //   [OptionalValidation]
      //  [Range(5, 6)]
        public string City { get; set; }

    //    [OptionalValidation]
      //  [Range(5, 10)]
        public int HouseNo { get; set; }

        
      //  [OptionalValidation]
      //  [Range(4, 4)]
        
        [StringLength(15)]
      //  [OptionalValidation]
        public string AddressLine1 { get; set; }

        [StringLength(15)]
       // [OptionalValidation]
        public string AddressLine2 { get; set; }

        [Required]
        public string State { get; set; }

        public decimal ShippingCharges { get; set; }

        public PaymentType CreditCard { get; set; }

        public bool SameAddress { get; set; }

        public bool SaveInfo { get; set; }

    }

    public class CreditCardInformation : CheckoutModel
    {
        public string CreditCardName { get; set; }

        [CreditCard]
        public string CreditCardNumber { get; set; }

        public string CreditCardExpiration { get; set; }

        public string CreditCardCvv { get; set; }
    }

    public enum PaymentType
    {
        CreditCard
    }
//    public class OptionalValidation : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            var fullCheckoutModel = validationContext.ObjectInstance as FullCheckOutModel;
//            if (fullCheckoutModel != null)
//            {
//                var ad1 = fullCheckoutModel.AddressLine1;
//                var ad2 = fullCheckoutModel.AddressLine2;
//                var zipCode = fullCheckoutModel.ZipCode;
//              //  var poBox = fullCheckoutModel.PoBox;
//                var houseNo = fullCheckoutModel.HouseNo;
//             //   var aprtNo = fullCheckoutModel.ApartmentNo;

//                if (string.IsNullOrEmpty(ad1) && string.IsNullOrEmpty(ad2))
//                {
//                    return new ValidationResult("Please enter valid Address", new List<string>(){ad1, ad2});
//                }

//                if (zipCode == 0 && poBox == 0)
//                {
//                    return new ValidationResult("Please enter valid zip or pobox");
//                }

//                if (zipCode > 0 && poBox > 0)
//                {
//                    return new ValidationResult("Please enter valid zip or pobox");
//                }

//                if (houseNo == 0 && aprtNo == 0)
//                {
//                    return new ValidationResult("Please enter valid house no or aprt No");
//                }

//                if (houseNo > 0 && aprtNo > 0)
//                {
//                    return new ValidationResult("Please enter valid house no or aprt No");
//                }

//            }
//            return ValidationResult.Success;
//        }
//    }
}