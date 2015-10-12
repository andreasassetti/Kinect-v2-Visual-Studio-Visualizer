using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    internal class InternalFaceFrame : Internal2DFrame
    {
        public InternalFaceFrame()
        {
            FacePointsInColorSpace = new Dictionary<InternalFacePointType, InternalPointF>();
            FacePointsInInfraredSpace = new Dictionary<InternalFacePointType, InternalPointF>();
        }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalDetectionResult FaceHappy { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalDetectionResult FaceEngaged { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalDetectionResult FaceWearingGlasses { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalDetectionResult FaceLeftEyeClosed { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalDetectionResult FaceRightEyeClosed { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalDetectionResult FaceMouthOpen { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalDetectionResult FaceMouthMoved { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalDetectionResult FaceLookingAway { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalVector4 FaceRotationQuaternion { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalRectI FaceBoundingBoxInColorSpace { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalRectI FaceBoundingBoxInInfraredSpace { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public ulong TrackingId { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public InternalFaceFrameFeatures FaceFrameFeatures { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public IReadOnlyDictionary<InternalFacePointType, InternalPointF> FacePointsInColorSpace { get; set; }

        [Category("FaceFrame")]
        [ReadOnly(true)]
        public IReadOnlyDictionary<InternalFacePointType, InternalPointF> FacePointsInInfraredSpace { get; set; }
    }
}