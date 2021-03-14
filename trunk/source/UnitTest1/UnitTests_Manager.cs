using System;
using Xunit;
using ClasseManager;
using ProjectClasses;

namespace UnitTest1
{
    public class UnitTests_Manager
    {
        /// <summary>
        /// Permet de faire des test pour savoir si il y a le bon nombre de sessions ou d'utilisateur instanciés
        /// </summary>
        [Fact]
        public void TestChargeDonnees()
        {
            /* Manager mng = new Manager();
             mng.ChargeDonnee();
             Assert.Equal(2, mng.Utilisateur.Count);
             Assert.Equal(7, mng.Session.Count);*//*
            Manager mng = new Manager();
            mng.LoadBdUser();
            Assert.Equal(3, mng.BdUser.ListeUtilisateur.Count);*/
        }
    }
}
