using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LooneyDog
{

    [RequireComponent(typeof(Rigidbody))]

    public class SpaceShipController : MonoBehaviour
    {

        [SerializeField]
        private float yawTorque = 500f;

        [SerializeField]
        private float pitchTorque = 500f;

        [SerializeField]
        private float rollTorque = 500f;

        [SerializeField]
        private float thrust = 100f;

        [SerializeField]
        private float upThrust = 50f;

        [SerializeField]
        private float strafeThrust = 50f;

        [SerializeField, Range(0.001f, 0.999f)]
        private float thrustGlideReduction = 0.999f;

        [SerializeField, Range(0.001f, 0.999f)]
        private float upDownGlidReduction = 0.111f;

        [SerializeField, Range(0.001f, 0.999f)]
        private float strafeGlideReduction = 0.111f;


        Rigidbody rb;

        private float thrust1D;
        private float upDown1D;
        private float strafe1D;
        private float roll1D;
        private Vector2 pitchYaw;
        private float glide = 0f;
        private float verticalGlide = 0f;
        private float horizontalGlide = 0f;


        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            //Roll on the Z axis which is z = 1
            rb.AddRelativeTorque(Vector3.forward * roll1D * rollTorque * Time.deltaTime);
            // Pitch which is side to side on the right x axis, negative y for normal updown and not inverted.
            rb.AddRelativeTorque(Vector3.right * Mathf.Clamp(-pitchYaw.y, -1f, 1f) * pitchTorque * Time.deltaTime);
            // Yaw which is up down on the up y axis
            rb.AddRelativeTorque(Vector3.up * Mathf.Clamp(pitchYaw.x, -1f, 1f) * yawTorque * Time.deltaTime);

            // Thrust
            if (thrust1D > 0.1f || thrust1D < -0.1f)
            {
                float currentThrust = thrust;

                rb.AddRelativeForce(Vector3.forward * thrust1D * currentThrust * Time.deltaTime);
                glide = thrust;

            }
            else
            {
                rb.AddRelativeForce(Vector3.forward * glide * Time.deltaTime);
                glide *= thrustGlideReduction; /*Every physics frame glide amount will be reduced and eventually will be 0*/
            }


            // Up/Down
            if (upDown1D > 0.1f || upDown1D < -0.1f)
            {
                rb.AddRelativeForce(Vector3.up * upDown1D * upThrust * Time.deltaTime);
                verticalGlide = upDown1D * upThrust;
            }
            else
            {
                rb.AddRelativeForce(Vector3.up * verticalGlide * Time.deltaTime);
                verticalGlide *= upDownGlidReduction;
            }

            // Strafe
            if (strafe1D > 0.1f || strafe1D < -0.1f)
            {
                rb.AddRelativeForce(Vector3.right * strafe1D * strafeThrust * Time.deltaTime);
                horizontalGlide = strafe1D * strafeThrust;
            }
            else
            {
                rb.AddRelativeForce(Vector3.right * horizontalGlide * Time.deltaTime);
                horizontalGlide *= strafeGlideReduction;
            }


        }


        #region InputRegion

        public void OnThrust(InputAction.CallbackContext context)
        {
            thrust1D = context.ReadValue<float>();
        }

        public void OnStrafe(InputAction.CallbackContext context)
        {
            strafe1D = context.ReadValue<float>();
        }

        public void OnUpDown(InputAction.CallbackContext context)
        {
            upDown1D = context.ReadValue<float>();
        }

        public void OnRoll(InputAction.CallbackContext context)
        {
            roll1D = context.ReadValue<float>();
        }

        public void OnPitchYaw(InputAction.CallbackContext context)
        {
            pitchYaw = context.ReadValue<Vector2>();
        }

        #endregion

    }

}

