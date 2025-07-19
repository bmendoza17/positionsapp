import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react"

export interface Department {
  id: number;
  name: string;
  description: string;
}

export const departmentsApiSlice = createApi({
  baseQuery: fetchBaseQuery({ baseUrl: "https://hikruapi-fbdshfg7hrbmeuh6.canadacentral-01.azurewebsites.net/api" }),
  reducerPath: "departmentsApi",
  tagTypes: ["Departments"],
  endpoints: (builder) => ({
    getDepartments: builder.query<Department[], void>({
      query: () => "departments",
      providesTags: (_result: Department[] | undefined, _error: unknown, _arg: void) => [{ type: "Departments" }],
    }),
  }),
});

export const { useGetDepartmentsQuery } = departmentsApiSlice;
