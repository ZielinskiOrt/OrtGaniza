// --- AÑADE ESTA LÍNEA AL PRINCIPIO ---
using System.Security.Claims;
// ------------------------------------

using System;
using System.Text;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;


// --- 1. REEMPLAZA ESTOS VALORES ---
string SHARED_SECRET = "IRY96t3deg0Lq4fBQxBvd38vi1xMIdVEHItXDpjlgQqBpe8EeSds5uLBQrRiqHwtxNNg9Ov61U00uLcRuxTa7Q";
string KEY_ID = "app_69148ca8019fa57f6fdf6d40";
string EXTERNAL_ID = "123456123456123456123456";
// ---
// --- 2. Preparar la clave de firma (Signing Key) ---
var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SHARED_SECRET));
var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); //
                                                                                             // ---
// --- 3. Crear el Encabezado (Header) ---
var header = new JwtHeader(signingCredentials);
header.Add("kid", KEY_ID); // Requerido por Zendesk 
// ---
// --- 4. CREAR LA CARGA ÚTIL (PAYLOAD) - (VERSIÓN CORREGIDA) ---
// Usamos una List<Claim> en lugar de un Dictionary
var claims = new List<Claim>
{
    // Requerido: El "scope" debe ser "user" 
    new Claim("scope", "user"),
    
    // Requerido: Tu ID de usuario interno 
    new Claim("external_id", EXTERNAL_ID),
    
    // "Issued At Time" (Cuándo se emitió). 
    // Fíjate que el valor se convierte a string.
    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
    // --- Opcional pero recomendado ---
    
    // El nombre de tu usuario 
    new Claim("name", "Ivan Zielinski"), 
    
    // El email de tu usuario 
    new Claim("email", "ivanezielinski@gmail.com"), 
    
    // ¡CRÍTICO! Si envías 'email', DEBES poner 'email_verified' en 'true' 
    // Fíjate que el valor booleano se pasa como string "true" y se le indica el tipo.
    new Claim("email_verified", "true", ClaimValueTypes.Boolean)
};
var payload = new JwtPayload(claims);
// ---
// --- 5. Crear y firmar el Token ---
var token = new JwtSecurityToken(header, payload);
var tokenHandler = new JwtSecurityTokenHandler();
var jwtTokenString = tokenHandler.WriteToken(token);
// --- 6. Mostrar el resultado ---
Console.WriteLine("--- TOKEN JWT PARA ZENDESK (copia esto) ---");
Console.WriteLine(jwtTokenString);
 