import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react"

export interface Recruiter {
  id: number;
  name: string;
  email: string;
}

export const recruiterApiSlice = createApi({
  reducerPath: "recruitersApi",
  baseQuery: fetchBaseQuery({ baseUrl: "https://hikruapi-fbdshfg7hrbmeuh6.canadacentral-01.azurewebsites.net/api" }),
  tagTypes: ["Recruiters"],
  endpoints: (builder) => ({
    getRecruiters: builder.query<Recruiter[], void>({
      query: () => "recruiters",
      providesTags: (_result: Recruiter[] | undefined, _error: unknown, _arg: void) => [{ type: "Recruiters" }],
    }),
  }),
});

export const { useGetRecruitersQuery } = recruiterApiSlice;
