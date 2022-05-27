using LORHAPI_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API.Manager
{
   
        public class InsertionManager
        {
            /// <summary>
            /// In first we put a basic Insertion and in second parameter we put the Insertion that we want to update
            /// </summary>
            /// <param name="CurrentInsertion"></param>
            /// <param name="Insertion"></param>
            public void PropUpdate(Insertion Insertion, Insertion CurrentInsertion)
            {
                CurrentInsertion.DateDebut = Insertion.DateDebut;
                CurrentInsertion.DateFin = Insertion.DateFin;
                CurrentInsertion.AgeMin = Insertion.AgeMin;
                CurrentInsertion.AgeMax = Insertion.AgeMax;
                CurrentInsertion.Departement = Insertion.Departement;
                CurrentInsertion.Description = Insertion.Description;
                CurrentInsertion.DiplomeRequis = Insertion.DiplomeRequis;
                CurrentInsertion.DiplomeObtenu = Insertion.DiplomeObtenu;
                CurrentInsertion.Duration = Insertion.Duration;
            }

            public string ErrorMessageVerificationMatchId(int Id)
            {
                return "Impossible to find Insertion with Id=" + Id;
            }
        }
    }

