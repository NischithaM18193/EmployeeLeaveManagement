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


🔑 OAuth (Open Authorization)
What is it?
OAuth is an authorization framework. It lets a user grant limited access to their resources on one service to another service without sharing credentials.

For example:
"Sign in with Google"
"Allow this app to access your GitHub repos"

OAuth defines several flows, but commonly used is OAuth 2.0.

Key Actors
Resource Owner: User
Client: App requesting access (e.g., Spotify)
Authorization Server: Issues tokens (e.g., Google Auth server)
Resource Server: Holds user data (e.g., Google Calendar)

How it works (simplified)
Client app redirects user to Authorization Server.
User authenticates and grants permission.
Authorization server returns an authorization code to the client.
Client exchanges code for access token (and optionally refresh token).
Client uses access token to call Resource Server APIs.
Tokens involved
Access token — used to access APIs
Refresh token — used to get a new access token when old one expires

Pros
✅ Allows third-party access without exposing user credentials
✅ Fine-grained permissions (scope of access)
✅ Tokens can be revoked

Cons
❌ More complex than simple JWT auth
❌ Requires more infrastructure (auth server, token exchange, etc.)

| Aspect       | JWT Authentication           | OAuth 2.0                                   |
| ------------ | ---------------------------- | ------------------------------------------- |
| Purpose      | Authentication (who you are) | Authorization (what you can do)             |
| Token type   | JWT                          | Access token (often JWT, but can be opaque) |
| Typical use  | API authentication (own app) | Third-party app access                      |
| Server state | Stateless                    | May be stateless or stateful                |
| Example      | User logs into app API       | App accesses Google Calendar on your behalf |
