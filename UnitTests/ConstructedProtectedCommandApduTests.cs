﻿using System;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU.Header;
using HelloWord.SecureMessaging;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ConstructedProtectedCommandApduTests
    {
        [Test]
        public void Construct_protected_APDU()
        {
            Assert.AreEqual(
                    "0CA4020C158709016375432908C044F68E08BF8B92D635FF24F800",
                    new Hex(
                        new ConstructedProtectedCommandApdu(
                            new BinaryHex("0CA4020C"), // apduHeader 
                            new BinaryHex("8709016375432908C044F6"), //DO87
                            new BinaryHex("8E08BF8B92D635FF24F8") //DO8E
                        )
                    ).ToString()
                );
        }

        [Test]
        public void Construct_protected_APDU2()
        {
            Assert.AreEqual(
                    "0CA4020C158709016375432908C044F68E08BF8B92D635FF24F800",
                    new Hex(
                        new ConstructedProtectedCommandApdu2(
                            new MaskedCommandApduHeader(new CommandApduHeader(new BinaryHex("00A4020C02011E"))), // rawCommandApdu 
                            new BinaryHex("8709016375432908C044F6"), //DO87
                            new BinaryHex(""), //DO97
                            new BinaryHex("8E08BF8B92D635FF24F8") //DO8E
                        )
                    ).ToString()
                );
        }
    }
}
