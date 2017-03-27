﻿using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using HelloWord.ISO7816.CommandAPDU.Body;
using HelloWord.SecureMessaging.DO;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.SecureMessaging.ResponseDO.DO87
{
    public class DO87ProtectedCommandApdu : IBinary
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _rawCommandApdu;


        public DO87ProtectedCommandApdu(
                IBinary rawCommandApduHeader,
                IBinary kSenc,
                IBinary kSmac,
                IBinary incrementedSsc
            )
        {
            _rawCommandApdu = rawCommandApduHeader;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _incrementedSsc = incrementedSsc;
        }
        public byte[] Bytes()
        {
            var do87 = new Binary();
                    //new BuildedDO87(
                    //       new EncryptedCommandApduData(
                    //           _kSenc,
                    //           new PadedCommandApduData(
                    //               new CommandApduData(
                    //                   new CommandApduBody(_rawCommandApdu)
                    //               )
                    //           )
                    //       )
                    //   );
            return new ProtectedCommandApdu(
                    _rawCommandApdu,
                    _kSmac,
                    _incrementedSsc,
                    do87
                ).Bytes();
        }
    }
}
