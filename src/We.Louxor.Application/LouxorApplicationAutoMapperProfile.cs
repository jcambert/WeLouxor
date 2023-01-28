using AutoMapper;
using System;
using Volo.Abp.AutoMapper;
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
                 new LigneDeCommande() {Societe=((string)record["sigsoc"]).Trim(), NumeroDocument = Convert.ToInt32( (double)record["numdoc"]), CodeArticle = ((string)record["codart"]).Trim(), PrixUnitaire = (double)record["tprixun"], QuantiteCommande = (double)record["quanti"], DelaiDemande = (DateOnly)record["datdem"], CodeClient = ((string)record["codcli"]).Trim() }
            );

        CreateMap<RecordData, Article>()
            .ConstructUsing(record =>
                new Article() { Societe = ((string)record["sigsoc"]).Trim(), Code = ((string)record["codart"]).Trim(), Designation = ((string)record["libart"]).Trim(), Domaine = ((string)record["coddom"]).Trim(), CoutMachineDirect =(double)record["etotmac"]+ (double)record["etotmod"], CoutMatiereDirect = (double)record["ecoumat"] }

            );

        CreateMap<RecordData, OrdreDeFabication>()
            .ConstructUsing(record =>
                new OrdreDeFabication() { Societe = ((string)record["sigsoc"]).Trim(), Numero = Convert.ToInt32((double)record["ordfab"]), CodeOperation = Convert.ToInt32((double)record["codope"]), NumeroAR = Convert.ToInt32((double)record["numdoc"]), CodeClient = ((string)record["codcli"]).Trim(), CodeArticle = ((string)record["codart"]).Trim(), Quantite = (double)record["qtepre"] }
                
            );

        CreateMap<RecordData, Client>()
            .ConstructUsing(record =>
                new Client() { Societe = ((string)record["sigsoc"]).Trim(), Code  = ((string)record["codfou"]).Trim(), Libelle= ((string)record["libfou"]).Trim() }

            );

        CreateMap<LigneInventaire, LigneInventaireDto>();

        CreateMap<LigneInventaireDto, LigneInventaire>()
              .IgnoreFullAuditedObjectProperties();
            
    }
}
