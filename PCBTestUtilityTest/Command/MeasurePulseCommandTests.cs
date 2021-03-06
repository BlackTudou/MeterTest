﻿/*
 * Copyright (C) 1994-2018 Microstar Electric Company Limited
 * 
 * All Rights Reserved.
 * 
 * LEGAL NOTICE: All information contained herein is, and 
 * remains the property of Microstar Electric Company Limited. 
 * The intellectual and technical concepts contained herein 
 * are proprietary to Microstar Electric Company Limited, and 
 * may be covered by patents, patents in process and are 
 * protected by the trade secret or copyright laws. Commercial 
 * use, or disclosure, or dissemination, or reproduction of 
 * the information contained in this file are strictly 
 * forbidden unless official specific written permissions are 
 * obtained from Microstar Electric Company Limited.
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microstar.Production.Comms.PCB;
using Microstar.Production.PCBTest.Command;

namespace Microstar.Production.PCBTest.Tests
{
    /// <summary>
    /// 脉冲检测命令类测试
    /// </summary>
    [TestClass]
    public class MeasurePulseCommandTests : UnitTestBase
    {
        /// <summary>
        /// 脉冲检测函数测试
        /// </summary>
        [TestMethod]
        public void ExecuteTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();
                var measurePulseCommand = new MeasurePulseCommand();

                CommandResult result = measurePulseCommand.Execute(client, null, null);

                int[] array = measurePulseCommand.GetPulseValue(result.Data);

                Assert.AreEqual(result.Data, "12,13,22,0,12,13,22,0");
                Assert.AreEqual(array[0], 12);
                Assert.AreEqual(array[1], 13);
                Assert.AreEqual(array[2], 22);
                Assert.AreEqual(array[3], 0);
                Assert.AreEqual(array[4], 12);
                Assert.AreEqual(array[5], 13);
                Assert.AreEqual(array[6], 22);
                Assert.AreEqual(array[7], 0);
            } 
        }
    }
}
