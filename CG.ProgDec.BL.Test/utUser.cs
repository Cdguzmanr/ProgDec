namespace CG.ProgDec.BL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void LoginSucessfullTest()
        {
            Seed();
            Assert.IsTrue(UserManager.Login(new User {UserId="bfoote", Password="maple" }) );
            Assert.IsTrue(UserManager.Login(new User { UserId = "kfrog", Password = "misspiggy" }));
        }

        public void Seed()
        {
            UserManager.Seed();
        }


        [TestMethod]
        public void InsertTest()
        {
           
        }

        [TestMethod]
        public void LoginFailureNoUserId()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserId= "", Password="maple" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);               
            }

        }

        [TestMethod]
        public void LoginFailureBadPassword()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserId = "bfoote", Password = "wrong" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void LoginFailureBadUSerId()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserId = "wrong", Password = "maple" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void LoginFailureNoPassword()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserId = "bfoote", Password = "" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
