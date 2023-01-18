using AutoMapper;
using System;
using We.Dbf;
using We.Louxor.InventaireArticle;

namespace We.Louxor;

public class LouxorApplicationAutoMapperProfile : Profile
{
    public LouxorApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<RecordData, LigneDeCommande>()
            .ConstructUsing(record =>
                 new LigneDeCommande() {Societe=(string)record["sigsoc" ], NumeroDocument = Convert.ToInt32( (double)record["numdoc"]), CodeArticle = (string)record["codart"], PrixUnitaire = (double)record["tprixun"], QuantiteCommande = (double)record["quanti"], DelaiDemande = (DateOnly)record["datdem"] }
            );

        CreateMap<RecordData, Article>()
            .ConstructUsing(record =>
                new Article() { Societe = (string)record["sigsoc"], Code = (string)record["codart"], Designation = (string)record["libart"], CoutMachineDirect =(double)record["ecoumac"], CoutMatiereDirect = (double)record["ecoumat"] }

            );
    }
}
