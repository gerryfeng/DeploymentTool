using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO;
using Web.DTO.Configure;
using Web.Models.ThreeConfigure;

namespace Web.Services.IOTPlatform.Configure
{
    public interface IThreeUnitService
    {

        Task<Results<ModelFeature>> GetFeatureByType(string Type);

        Task<Results<ModelFeatureData>> GetFeatureDataByTypeAndFeature(string Type, string Feature);

        Task<Results<ModelFeatureData>> GetModelByDefault();

        Status AddThreeSketch(ThreeSketch sketchInfo);

        Status EditThreeSketch(ThreeSketch sketchInfo);
        Results<ThreeSketch> QueryAllThreeSketch();

        Results<ThreeSketch> QueryThreeSketchById(int id);

        Status DeleteThreeSketch(string ids);

        Status AddThreeModelGroup(ThreeModelGroup modelGroup);

        Results<ThreeModelGroup> QueryAllThreeModelGroup();

        Results<ThreeModelGroup> QueryThreeModelGroupById(int id);

        Status DeleteModelGroup(string ids);

        Status AddThreeModel(ThreeModel threeModel);
        Results<ModelResult> QueryAllThreeModel();
        Results<ModelResult> QueryThreeModelByGroup(long groupID);
        Status DeleteThreeModel(string ids);

        Results<Stream> ExportModel(long id);
    }
}
