🔐 JWT Authentication (JSON Web Token)

What is it?
JWT (JSON Web Token) is a compact, URL-safe token format used to securely transmit information between parties.
It is typically used for stateless authentication in APIs.

Structure:
A JWT looks like this:
xxxxx.yyyyy.zzzzz
It has 3 parts:
Header — contains token type (JWT) and signing algorithm (e.g., HS256)
Payload — contains claims (user info, permissions, expiry time, etc.)
Signature — ensures that the token is not tampered with

How it works?
User sends login credentials (username/password) to the server.
Server verifies the credentials.
If valid, server creates a JWT and signs it.
Server sends the JWT back to the client.
Client stores the JWT (usually in local storage or in a cookie).
On each subsequent request, client sends JWT in Authorization header:

Authorization: Bearer <JWT>
Server verifies the token and grants access.

Pros
✅ Stateless (no need to store session on server)
✅ Can include user info / roles in token
✅ Portable (works across domains, services)

Cons
❌ Token cannot be revoked easily unless expiry is short
❌ If token is stolen, attacker has access until token expires
