﻿// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.ModelBlock.Behaviours;
using SWE1R.Assets.Blocks.Unity.Extensions;
using System.Collections.Generic;
using System.Linq;
using Swe1rBehaviour = SWE1R.Assets.Blocks.ModelBlock.Behaviours.Behaviour;
using UnityVector3 = UnityEngine.Vector3;
using UnityVector3Int = UnityEngine.Vector3Int;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Behaviours
{
    public class BehaviourWrapper : ModelScriptableObjectWrapper<Swe1rBehaviour>
    {
        #region Fields

        public short word_00;
        public byte fogFlags;
        public UnityVector3Int fogColor;
        public ushort fogStart;
        public ushort fogEnd;
        public ushort lightFlags;
        public UnityVector3Int ambientColor;
        public UnityVector3Int lightColor;
        public byte byte_12;
        public byte byte_13;
        public UnityVector3 lightVector;
        public float float_20;
        public float float_24;
        public VehicleReaction vehicleReaction;
        public short word_30;
        public short word_32;
        public List<TriggerReferenceWrapper> subs;

        #endregion

        #region Methods

        public override void Import(Swe1rBehaviour source, ModelBlockItemImporter importer)
        {
            word_00 = source.Word_00;
            fogFlags = source.FogFlags;
            fogColor = source.FogColor.ToUnityVector3Int();
            fogStart = source.FogStart;
            fogEnd = source.FogEnd;
            lightFlags = source.LightFlags;
            ambientColor = source.AmbientColor.ToUnityVector3Int();
            lightColor = source.LightColor.ToUnityVector3Int();
            byte_12 = source.Byte_12;
            byte_13 = source.Byte_13;
            lightVector = source.LightVector.ToUnityVector3();
            float_20 = source.Float_20;
            float_24 = source.Float_24;
            vehicleReaction = source.VehicleReaction;
            word_30 = source.Word_30;
            word_32 = source.Word_32;
            subs = source.Subs.Select(x => importer.GetTriggerReferenceScriptableObject(x)).ToList();
        }

        public override Swe1rBehaviour Export(ModelBlockItemExporter exporter) =>
            new() {
                Word_00 = word_00,
                FogFlags = fogFlags,
                FogColor = fogColor.ToSwe1rVector3Byte(),
                FogStart = fogStart,
                FogEnd = fogEnd,
                LightFlags = lightFlags,
                AmbientColor = ambientColor.ToSwe1rVector3Byte(),
                LightColor = lightColor.ToSwe1rVector3Byte(),
                Byte_12 = byte_12,
                Byte_13 = byte_13,
                LightVector = lightVector.ToSwe1rVector3Single(),
                Float_20 = float_20,
                Float_24 = float_24,
                VehicleReaction = vehicleReaction,
                Word_30 = word_30,
                Word_32 = word_32,
                Subs = subs.Select(s => s.Export(exporter)).ToList(),
            };

        #endregion
    }
}
